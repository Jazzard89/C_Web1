using Microsoft.AspNetCore.Mvc;
using Samenvatting1.Data;
using Samenvatting1.Models;

namespace Samenvatting1.Controllers
{
    public class LanguageController : Controller
    {
        private readonly AppDbContext _context;
        public LanguageController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Languages);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var language = new Languages();
            return View(language);
        }

        [HttpPost]
        public IActionResult Add(Languages model)
        {
            if (ModelState.IsValid)
            {
                AddLanguage(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public void AddLanguage(Languages language)
        {
            _context.Languages.Add(language);
            _context.SaveChanges();
        }
    }
}
