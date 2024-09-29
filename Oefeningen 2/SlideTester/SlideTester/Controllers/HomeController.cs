using Microsoft.AspNetCore.Mvc;

namespace SlideTester.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
