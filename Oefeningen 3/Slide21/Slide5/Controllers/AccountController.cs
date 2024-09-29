using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Slide5.Data;
using Slide5.ViewModels;

namespace Slide5.Controllers
{
    public class AccountController : Controller
    {
        PartyContext _context;
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        public AccountController(PartyContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityUser = await _userManager.FindByNameAsync(model.Email);
                identityUser.Email = model.Email;
                identityUser.UserName = model.Email;
                var result = await _signInManager.PasswordSignInAsync(identityUser, model.Password, false, false);
                
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    if (result.IsNotAllowed)
                    {
                        ModelState.AddModelError("", "User not allowed!");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Can not login!");
                    }
                }
            }
            return View();
        }

        #endregion


        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password.Equals(model.ConfirmPassword))
                {
                    var identityUser = new IdentityUser();
                    identityUser.Email = model.Email;
                    identityUser.UserName = model.Email;
                    var result = _userManager.CreateAsync(identityUser, model.Password).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                    
                }
                else
                {
                    ModelState.AddModelError("", "Password & comp pwd are not the same!");
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
    }
}
