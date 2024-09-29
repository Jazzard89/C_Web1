using Microsoft.AspNetCore.Mvc;
using Oef4MvcClientLocation.Data;
using Oef4MvcClientLocation.Models;
using System.Diagnostics;

namespace Oef4MvcClientLocation.Controllers
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
            int counterClients = 0;
            int counterLocations = 0;
            foreach (var client in Database.Clients)
            {
                counterClients++;
            }
            foreach (var location in Database.Locations)
            {
                counterLocations++;
            }
            ViewBag.ClientCount = counterClients;
            ViewBag.LocationCount = counterLocations;

            return View();
        }

        public IActionResult Overview()
        {

            return View("~/Views/ClientLocation/Index.cshtml"); 
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