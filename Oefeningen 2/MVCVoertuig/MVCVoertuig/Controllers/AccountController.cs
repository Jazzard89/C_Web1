using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.ViewModels;

namespace MVCVoertuig.Controllers
{
    public class AccountController : Controller
    {
        #region login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            return View();
        }
        #endregion
        #region register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(LoginViewModel user)
        {
            return View();
        }
        #endregion
    }
}
