using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCVoertuig.Data;
using MVCVoertuig.Models;

namespace MVCVoertuig.Controllers
{
    [Authorize]
    public class VoertuigController : Controller
    {
        public VoertuigDbContext _context;
        public VoertuigController(VoertuigDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var voertuigen = _context.Voertuigen;
            return View(voertuigen);
        }
        public IActionResult Merk(string merk)
        {
            ViewBag.Merk = merk;
            return View(_context.Voertuigen.Where(x => x.Merk == merk));
        }

        [HttpGet]
        public IActionResult Create()
        {
            var voertuigen = new Voertuig();
            return View(voertuigen);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Create(Voertuig voertuigen)
        {
            if (ModelState.IsValid)
            {
                _context.Voertuigen.Add(voertuigen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voertuigen);
        }
    }
}
