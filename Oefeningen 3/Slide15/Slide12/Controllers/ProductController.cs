using Microsoft.AspNetCore.Mvc;
using Slide12.Data;
using Slide12.Models;

namespace Slide12.Controllers
{
    public class ProductController : Controller
    {
        readonly AppDbContext _context;
        readonly Repositories.ProductRepository _repository;
        public ProductController(AppDbContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            var product = new Product();
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Invalid Data! -> {ex.Message.ToString()}");
                }
            }
            return View(product);
        }
    }
}
