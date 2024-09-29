using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Slide23.Data;
using Slide23.Models.ViewModels;

namespace Slide23.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        private readonly AppDbContext _context;
        RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<IdentityUser> userManager, AppDbContext context, SignInManager<IdentityUser> signInManger, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _signInManager = signInManger;
            _roleManager = roleManager;
        }

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var identityUser = await _userManager.FindByEmailAsync(model.Email);
        //        identityUser.Email = model.Email;
        //        identityUser.UserName = model.Email;

        //        var result = await _signInManager.PasswordSignInAsync(identityUser, model.Password, false, false);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            if (result.IsNotAllowed)
        //            {
        //                ModelState.AddModelError("", "User not allowed");
        //            }
        //            else
        //            {
        //                ModelState.AddModelError("", "Can not login");
        //            }
        //        }

        //    }
        //    return View();
        //}

        public async Task<IActionResult> LoginAsync(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityUser = await _userManager.FindByEmailAsync(model.Email);
                if (identityUser != null)
                {
                    // Check if the email is confirmed
                    //if (!await _userManager.IsEmailConfirmedAsync(identityUser))
                    //{
                    //    ModelState.AddModelError("", "You need to confirm your email before you can log in.");
                    //    return View(model);
                    //}

                    // Check if the user is locked out
                    if (await _userManager.IsLockedOutAsync(identityUser))
                    {
                        ModelState.AddModelError("", "Your account is locked out.");
                        return View(model);
                    }

                    // Attempt to sign in
                    var signInResult = await _signInManager.PasswordSignInAsync(identityUser.UserName, model.Password, false, false);
                    if (signInResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (signInResult.IsNotAllowed)
                    {
                        ModelState.AddModelError("", "User not allowed to log in.");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid login attempt.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "No user found with this email.");
                }
            }

            return View(model);
        }
        #endregion

        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.RoleId = new SelectList(_context.Roles, "Id", "Name");
            return View();
        }

        [HttpPost]
        //public IActionResult Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (model.Password.Equals(model.ConfirmPassword))
        //        {
        //            var identityUser = new IdentityUser();
        //            identityUser.Email = model.Email;
        //            identityUser.UserName = model.Email;
        //            var result = _userManager.CreateAsync(identityUser, model.Password).Result;
        //            if (result.Succeeded)
        //            {
        //                return RedirectToAction("Index", "Home");
        //            }
        //            else
        //            {
        //                foreach (var error in result.Errors)
        //                {
        //                    ModelState.AddModelError("", error.Description);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Password & comp pwd are not the same!");
        //        }
        //    }
        //    return View();


        //}
        public async Task<IActionResult> RegisterAsync(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.RoleId != null)
                {
                    var identityUser = new IdentityUser();
                    identityUser.Email = model.Email;
                    identityUser.UserName = model.Email;
                    var identityResult = await _userManager.CreateAsync(identityUser, model.Password);

                    if (identityResult.Succeeded)
                    {
                        var identityRole = await _roleManager.FindByIdAsync(model.RoleId);
                        
                        //var roleName = _context.Roles.Where(x => x.Id == model.RoleId).First().Name;
                        var roleResult = await _userManager.AddToRoleAsync(identityUser, identityRole.Name);

                        if (roleResult.Succeeded)
                        {
                            return View("Login");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Probleem met toekennen van rol!");
                            return View();
                        }
                        
                    }
                    foreach (var error in identityResult.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Geen rol geselecteerd!");
                }
            }
            return View();
        }
        #endregion

        #region Logout
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }

        #endregion

        [HttpGet]
        public IActionResult Identity()
        {
            var identityViewModel = new IdentityViewModel();
            identityViewModel.Roles = _roleManager.Roles;
            identityViewModel.Users = _userManager.Users;

            var rolesDebug = identityViewModel.Roles.ToList();

            return View(identityViewModel);
        }
    }
}
