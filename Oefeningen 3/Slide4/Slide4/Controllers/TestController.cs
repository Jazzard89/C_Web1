using Microsoft.AspNetCore.Mvc;
using Slide4.Models;

namespace Slide4.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestViewBag()
        {
            ViewBag.Teller = 3;
            return View();
        }

        public IActionResult TestViewData()
        {
            ViewData["Teller"] = 3;
            return View();
        }

        public IActionResult Formulier()
        {
            return View();
        }

        public IActionResult FormulierPost()
        {
            string invoer = Request.Form["TestInvoer"];
            TestModel model = new TestModel();
            model.TestInvoer = invoer;
            return View(model);
        }
    }
}
