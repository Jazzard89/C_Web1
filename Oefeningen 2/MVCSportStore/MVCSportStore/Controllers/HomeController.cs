using Microsoft.AspNetCore.Mvc;
using MVCSportStore.Data;
using MVCSportStore.Models;
using MVCSportStore.ViewModels;
using System.Diagnostics;

namespace MVCSportStore.Controllers
{
    public class HomeController : Controller
    {
        private StoreDbContext _context;
        private ProductRepository _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, StoreDbContext context)
        {
            _context = context;
            _repo = new ProductRepository(context);
            _logger = logger;
        }

        public IActionResult Index(int id = 1, string category=null)
        {
            if (category != null)
            {
                AddRouteKey("category", category);
            }
            var productModel = _repo.GetProductModel(id, category);
            return View(productModel);
        }
        private void AddRouteKey(string key, string keyValue)
        {
            if (base.RouteData.Values.ContainsKey(key))
            {
                base.RouteData.Values[key] = keyValue;
            }
            else
            {
                base.RouteData.Values.Add(key, keyValue);
            }
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