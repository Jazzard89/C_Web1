using Microsoft.AspNetCore.Mvc;
using MVCSportStore.Data;
using MVCSportStore.Models;

namespace MVCSportStore.Controllers
{
    public class ResellerController : Controller
    {
        StoreDbContext _context;
        public ResellerController(StoreDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Resellers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var resellers = new Reseller();
            return View(resellers);
        }

        [HttpPost]
        public IActionResult Create(Reseller reseller)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Resellers.Add(reseller);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Invalid Data! ->" + ex.Message.Substring(50));
                }

            }
            return View();
        }
    }
}
