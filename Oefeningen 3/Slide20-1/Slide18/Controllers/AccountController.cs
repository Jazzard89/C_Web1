using Microsoft.AspNetCore.Mvc;
using Slide18.Models.ViewModels;

namespace Slide18.Controllers
{
    public class AccountController : Controller
    {
        #region Login

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            return View(user);
        }

        #endregion
        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(LoginViewModel user)
        {
            return View(user);
        }

        #endregion
    }
}
