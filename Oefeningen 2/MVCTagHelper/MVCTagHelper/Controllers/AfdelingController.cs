using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCTagHelper.Data;
using MVCTagHelper.Models;
using MVCTagHelper.ViewModels;

namespace MVCTagHelper.Controllers
{
    public class AfdelingController : Controller
    {
        private readonly TagHelperDbContext _context;

        public AfdelingController(TagHelperDbContext context)
        {
            _context = context;
        }

        // GET: Afdeling
        public async Task<IActionResult> Index()
        {
            var tagHelperDbContext = _context.Afdeling.Include(a => a.Locatie);
            return View(await tagHelperDbContext.ToListAsync());
        }

        // GET: Afdeling/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Afdeling == null)
            {
                return NotFound();
            }

            var afdeling = await _context.Afdeling
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
        public ActionResult Create()
        {
            var afdeling = new Afdeling();
            ViewData["LocatieId"] = new SelectList(_context.Locatie, "LocatieId", "LocatieId");
            return View(afdeling);
        }


        [HttpPost]
        public ActionResult Create(Afdeling afdeling)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Afdeling.Add(afdeling);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Invalid Data! ->" + ex.Message.Substring(50));
                }

            }
            ViewData["LocatieId"] = new SelectList(_context.Locatie, "LocatieId", "LocatieId");
            return View();

        }











        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Afdeling == null)
            {
                return NotFound();
            }

            var afdeling = await _context.Afdeling.FindAsync(id);
            if (afdeling == null)
            {
                return NotFound();
            }
            ViewData["LocatieId"] = new SelectList(_context.Locatie, "LocatieId", "LocatieId", afdeling.LocatieId);
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
            ViewData["LocatieId"] = new SelectList(_context.Locatie, "LocatieId", "LocatieId", afdeling.LocatieId);
            return View(afdeling);
        }

        // GET: Afdeling/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Afdeling == null)
            {
                return NotFound();
            }

            var afdeling = await _context.Afdeling
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
            if (_context.Afdeling == null)
            {
                return Problem("Entity set 'TagHelperDbContext.Afdeling'  is null.");
            }
            var afdeling = await _context.Afdeling.FindAsync(id);
            if (afdeling != null)
            {
                _context.Afdeling.Remove(afdeling);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AfdelingExists(int id)
        {
          return (_context.Afdeling?.Any(e => e.AfdelingId == id)).GetValueOrDefault();
        }
    }
}
