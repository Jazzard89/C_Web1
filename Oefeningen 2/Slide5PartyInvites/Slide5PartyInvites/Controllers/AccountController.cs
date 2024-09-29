using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Slide5PartyInvites.Data;
using Slide5PartyInvites.ViewModels;

namespace Slide5PartyInvites.Controllers
{
    public class AccountController : Controller
    {
        PartyContext _context;
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        public AccountController(PartyContext context,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var identityUser = await _userManager.FindByEmailAsync(loginViewModel.Email);
        //        if (identityUser != null)
        //        {
        //            var result = await _signInManager.PasswordSignInAsync(identityUser, loginViewModel.Password, false, false);
        //        }
        //        identityUser.Email = loginViewModel.Email;
        //        identityUser.UserName = loginViewModel.Email;
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View();
        //}
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var identityUser = await SearchIdentityUserAsync(loginViewModel.Email);
                if (identityUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(identityUser, loginViewModel.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        if (result.IsNotAllowed)
                        {
                            ModelState.AddModelError("", "User not allowed");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Can not login!");
                        }
                    }
                }
                //identityUser.Email = loginViewModel.Email;
                //identityUser.UserName = loginViewModel.Email;
                
            }
            return View();
        }





        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                if (registerViewModel.Password.Equals(registerViewModel.ConfirmPassword))
                {
                    var identityUser = new IdentityUser();
                    identityUser.Email = registerViewModel.Email;
                    identityUser.UserName = registerViewModel.Email;
                    var result = await _userManager.CreateAsync(identityUser, registerViewModel.Password);
                    
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
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

        private async Task<IdentityUser> SearchIdentityUserAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return View("Login");
        }

    }
}
