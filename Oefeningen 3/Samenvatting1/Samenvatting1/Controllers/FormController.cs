using Microsoft.AspNetCore.Mvc;
using Samenvatting1.Models;

namespace Samenvatting1.Controllers
{
    public class FormController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult FormPost()
        {
            string invoerName = Request.Form["languageNameInput"];
            string invoerFramework = Request.Form["languageFrameworkInput"];
            Languages model = new Languages();
            model.LanguageName = invoerName;
            model.Framework = invoerFramework;
            return View(model);
        }
    }
}
