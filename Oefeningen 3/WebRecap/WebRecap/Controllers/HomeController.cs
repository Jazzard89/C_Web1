using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using WebRecap.Models;
using WebRecap.Models.ViewModels;

namespace WebRecap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;
        private PagingInfo pageInfo = new PagingInfo();

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            ViewData["PagingInfo"] = pageInfo;
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["PagingInfo"] = pageInfo;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult DownloadFile(string fileName)
        {
            // Combine the root path with the wwwroot/downloads folder and the file name
            var filePath = Path.Combine(_env.WebRootPath, "downloads", fileName);

            if (System.IO.File.Exists(filePath))
            {
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "application/octet-stream", fileName);
            }
            else
            {
                return NotFound();
            }
        }
    }
}