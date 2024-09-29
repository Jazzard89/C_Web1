using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCClientLocEFCore.Data;
using MVCClientLocEFCore.Models;
using System.Diagnostics;

namespace MVCClientLocEFCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClientLocationContext _context;

        public HomeController(ILogger<HomeController> logger, ClientLocationContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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