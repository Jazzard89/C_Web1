using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Slide14.Data;
using Slide14.Models;

namespace Slide14.Controllers
{
    public class LocatieController : Controller
    {
        private readonly AppDbContext _context;

        public LocatieController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Locatie
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.locaties.Include(l => l.Land);
            return View(await appDbContext.ToListAsync());
            //return View(_context.locaties);
        }

        // GET: Locatie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.locaties == null)
            {
                return NotFound();
            }

            var locatie = await _context.locaties
                .Include(l => l.Land)
                .FirstOrDefaultAsync(m => m.LocatieId == id);
            if (locatie == null)
            {
                return NotFound();
            }

            return View(locatie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["LandId"] = new SelectList(_context.landen, "LandId", "LandId");
            var locaties = new Locatie();
            return View(locaties);
        }


        [HttpPost]
        public IActionResult Create(Locatie locatie)
        {
            locatie.Land = _context.landen.Where(x => x.LandId == locatie.LandId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                _context.Add(locatie);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewData["LandId"] = new SelectList(_context.landen, "LandId", "LandId", locatie.LandId);

            return View(locatie);



        }

        // GET: Locatie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.locaties == null)
            {
                return NotFound();
            }

            var locatie = await _context.locaties.FindAsync(id);
            if (locatie == null)
            {
                return NotFound();
            }
            ViewData["LandId"] = new SelectList(_context.landen, "LandId", "LandId", locatie.LandId);
            return View(locatie);
        }

        // POST: Locatie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LocatieId,Stad,LandId")] Locatie locatie)
        {
            if (id != locatie.LocatieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locatie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocatieExists(locatie.LocatieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["LandId"] = new SelectList(_context.landen, "LandId", "LandId", locatie.LandId);
            return View(locatie);
        }

        // GET: Locatie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.locaties == null)
            {
                return NotFound();
            }

            var locatie = await _context.locaties
                .Include(l => l.Land)
                .FirstOrDefaultAsync(m => m.LocatieId == id);
            if (locatie == null)
            {
                return NotFound();
            }

            return View(locatie);
        }

        // POST: Locatie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.locaties == null)
            {
                return Problem("Entity set 'AppDbContext.locaties'  is null.");
            }
            var locatie = await _context.locaties.FindAsync(id);
            if (locatie != null)
            {
                _context.locaties.Remove(locatie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocatieExists(int id)
        {
          return (_context.locaties?.Any(e => e.LocatieId == id)).GetValueOrDefault();
        }
    }
}
