using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCSportStore.Data;
using MVCSportStore.Models;

namespace MVCSportStore.Controllers
{
    public class ProductController : Controller
    {
        public StoreDbContext _context;
        public ProductController(StoreDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }



        [HttpGet]
        public ActionResult Create()
        {
            var product = new Product();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Invalid Data! ->" +  ex.Message.Substring(50));
                }

            }
            return View();
        }
    }
}
