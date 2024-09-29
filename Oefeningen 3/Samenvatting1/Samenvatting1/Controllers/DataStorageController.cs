using Microsoft.AspNetCore.Mvc;

namespace Samenvatting1.Controllers
{
    public class DataStorageController : Controller
    {
        public IActionResult ViewbagIndex()
        {
            ViewBag.Testdatabag1 = "Dit is de data";
            ViewBag.Testdatabag2 = 4;
            return View();
        }

        public IActionResult ViewDataIndex()
        {
            ViewData["Testdata1"] = "Dit is de data";
            ViewData["Testdata2"] = 4;
            return View();
        }
    }
}
