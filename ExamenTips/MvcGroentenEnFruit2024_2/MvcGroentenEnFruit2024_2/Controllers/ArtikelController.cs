using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit2024_2.Data;
using MvcGroentenEnFruit2024_2.Models;

namespace MvcGroentenEnFruit2024_2.Controllers
{
    public class ArtikelController : Controller
    {
        private readonly AppDbContext _context;

        public ArtikelController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
              return _context.Artikels != null ? 
                          View(await _context.Artikels.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Artikels'  is null.");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Artikels == null)
            {
                return NotFound();
            }

            var artikel = await _context.Artikels
                .FirstOrDefaultAsync(m => m.ArtikelId == id);
            if (artikel == null)
            {
                return NotFound();
            }

            return View(artikel);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtikelId,ArtikelNaam")] Artikel artikel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artikel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artikel);
        }


        private bool ArtikelExists(int id)
        {
          return (_context.Artikels?.Any(e => e.ArtikelId == id)).GetValueOrDefault();
        }
    }
}
