using Microsoft.AspNetCore.Mvc;
using Slide06ModelValidation.Models;
using System.Diagnostics;

namespace Slide06ModelValidation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult TestValidation()
        {
            TestValidation tv = new TestValidation();
            return View(tv);
        }
        [HttpPost]
        public IActionResult TestValidation(TestValidation tv)
        {
            if(ModelState.IsValid)
            {
                return View("Index");
            }
            return View(tv);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}