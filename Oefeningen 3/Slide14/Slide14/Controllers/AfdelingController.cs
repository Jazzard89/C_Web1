using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Slide14.Data;
using Slide14.Models;
using Slide14.ViewModels;

namespace Slide14.Controllers
{
    public class AfdelingController : Controller
    {
        private readonly AppDbContext _context;

        public AfdelingController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Afdeling
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.afdelingen.Include(a => a.Locatie);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Afdeling/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.afdelingen == null)
            {
                return NotFound();
            }

            var afdeling = await _context.afdelingen
                .Include(a => a.Locatie)
                .ThenInclude(l => l.Land)
                .FirstOrDefaultAsync(m => m.AfdelingId == id);
            if (afdeling == null)
            {
                return NotFound();
            }
            var afdelingCard = new AfdelingCard(afdeling);

            return View(afdelingCard);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["LocatieId"] = new SelectList(_context.locaties, "LocatieId", "LocatieId");
            var afdeling = new Afdeling();
            return View(afdeling);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Afdeling afdeling)
        {
            afdeling.Locatie = _context.locaties.Where(x => x.LocatieId == afdeling.LocatieId).FirstOrDefault();
            if (ModelState.IsValid)
            {
                _context.Add(afdeling);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LocatieId"] = new SelectList(_context.locaties, "LocatieId", "LocatieId", afdeling.LocatieId);
            return View(afdeling);
        }

        // GET: Afdeling/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.afdelingen == null)
            {
                return NotFound();
            }

            var afdeling = await _context.afdelingen.FindAsync(id);
            if (afdeling == null)
            {
                return NotFound();
            }
            ViewData["LocatieId"] = new SelectList(_context.locaties, "LocatieId", "LocatieId", afdeling.LocatieId);
            return View(afdeling);
        }

        // POST: Afdeling/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AfdelingId,AfdelingNaam,LocatieId")] Afdeling afdeling)
        {
            if (id != afdeling.AfdelingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(afdeling);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfdelingExists(afdeling.AfdelingId))
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
            ViewData["LocatieId"] = new SelectList(_context.locaties, "LocatieId", "LocatieId", afdeling.LocatieId);
            return View(afdeling);
        }

        // GET: Afdeling/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.afdelingen == null)
            {
                return NotFound();
            }

            var afdeling = await _context.afdelingen
                .Include(a => a.Locatie)
                .FirstOrDefaultAsync(m => m.AfdelingId == id);
            if (afdeling == null)
            {
                return NotFound();
            }

            return View(afdeling);
        }

        // POST: Afdeling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.afdelingen == null)
            {
                return Problem("Entity set 'AppDbContext.afdelingen'  is null.");
            }
            var afdeling = await _context.afdelingen.FindAsync(id);
            if (afdeling != null)
            {
                _context.afdelingen.Remove(afdeling);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfdelingExists(int id)
        {
          return (_context.afdelingen?.Any(e => e.AfdelingId == id)).GetValueOrDefault();
        }
    }
}
