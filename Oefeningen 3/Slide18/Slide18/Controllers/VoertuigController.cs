using Microsoft.AspNetCore.Mvc;
using Slide18.Data;
using Slide18.Models;

namespace Slide18.Controllers
{
    public class VoertuigController : Controller
    {
        private readonly AppDbContext _context;
        public VoertuigController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Voertuigen);
        }
        public IActionResult Merk(string merk)
        {
            ViewBag.Merk = merk;
            return View(_context.Voertuigen.Where(x => x.Merk == merk));   
        }

        [HttpGet]
        public IActionResult Create()
        {
            var voertuig = new Voertuig();
            return View(voertuig);
        }
        [HttpPost]
        public IActionResult Create(Voertuig voertuig)
        {
            if (ModelState.IsValid && voertuig != null)
            {
                _context.Voertuigen.Add(voertuig);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(voertuig);
        }
    }
}
