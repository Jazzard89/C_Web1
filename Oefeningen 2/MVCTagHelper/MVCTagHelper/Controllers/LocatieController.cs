using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTagHelper.Data;
using MVCTagHelper.Models;

namespace MVCTagHelper.Controllers
{
    public class LocatieController : Controller
    {
        private readonly TagHelperDbContext _context;

        public LocatieController(TagHelperDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tagHelperDbContext = _context.Locatie.Include(l => l.Land);
            return View(await tagHelperDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Locatie == null)
            {
                return NotFound();
            }

            var locatie = await _context.Locatie
                .Include(l => l.Land)
                .FirstOrDefaultAsync(m => m.LocatieId == id);
            if (locatie == null)
            {
                return NotFound();
            }

            return View(locatie);
        }

        public IActionResult Create()
        {
            ViewData["LandId"] = new SelectList(_context.Land, "LandId", "LandId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocatieId,Stad,LandId")] Locatie locatie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(locatie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LandId"] = new SelectList(_context.Land, "LandId", "LandId", locatie.LandId);
            return View(locatie);
        }

        // GET: Locatie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Locatie == null)
            {
                return NotFound();
            }

            var locatie = await _context.Locatie.FindAsync(id);
            if (locatie == null)
            {
                return NotFound();
            }
            ViewData["LandId"] = new SelectList(_context.Land, "LandId", "LandId", locatie.LandId);
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
            ViewData["LandId"] = new SelectList(_context.Land, "LandId", "LandId", locatie.LandId);
            return View(locatie);
        }

        // GET: Locatie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Locatie == null)
            {
                return NotFound();
            }

            var locatie = await _context.Locatie
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
            if (_context.Locatie == null)
            {
                return Problem("Entity set 'TagHelperDbContext.Locatie'  is null.");
            }
            var locatie = await _context.Locatie.FindAsync(id);
            if (locatie != null)
            {
                _context.Locatie.Remove(locatie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocatieExists(int id)
        {
          return (_context.Locatie?.Any(e => e.LocatieId == id)).GetValueOrDefault();
        }
    }
}
