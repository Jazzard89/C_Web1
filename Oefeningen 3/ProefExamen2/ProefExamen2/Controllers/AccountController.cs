using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProefExamen2.Data;
using ProefExamen2.Models.ViewModels;

namespace ProefExamen2.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("Email", "Email not found");
                }
                else
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Invalid password");
                    }
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Register()
        {

            var roles = _roleManager.Roles.Select(role => new SelectListItem
            {
                Value = role.Id,
                Text = role.Name
            }).ToList();


            ViewBag.Roles = new SelectList(roles, "Value", "Text");


            RegisterViewModel model = new RegisterViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            var roles = _roleManager.Roles.Select(role => new SelectListItem
            {
                Value = role.Id,
                Text = role.Name
            }).ToList();


            ViewBag.Roles = new SelectList(roles, "Value", "Text");


            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());
                if (role == null)
                {
                    ModelState.AddModelError("RoleId", "Role not found");
                }
                else
                {
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, role.Name);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

                
            }
            return View(model);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
