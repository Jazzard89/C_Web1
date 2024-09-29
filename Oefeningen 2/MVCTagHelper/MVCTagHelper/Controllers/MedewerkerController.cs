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
    public class MedewerkerController : Controller
    {
        private readonly TagHelperDbContext _context;

        public MedewerkerController(TagHelperDbContext context)
        {
            _context = context;
        }

        // GET: Medewerker
        public async Task<IActionResult> Index()
        {
            var tagHelperDbContext = _context.Medewerker.Include(m => m.Afdeling);
            return View(await tagHelperDbContext.ToListAsync());
        }



        // GET: Medewerker/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medewerker == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerker
                .Include(m => m.Afdeling)
                .FirstOrDefaultAsync(m => m.MedewerkerId == id);
            if (medewerker == null)
            {
                return NotFound();
            }

            return View(medewerker);
        }

        // GET: Medewerker/Create
        public IActionResult Create()
        {
            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "AfdelingId", "AfdelingId");
            return View();
        }

        // POST: Medewerker/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MedewerkerId,Naam,Voornaam,Email,AfdelingId")] Medewerker medewerker)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medewerker);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "AfdelingId", "AfdelingId", medewerker.AfdelingId);
            return View(medewerker);
        }

        // GET: Medewerker/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medewerker == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerker.FindAsync(id);
            if (medewerker == null)
            {
                return NotFound();
            }
            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "AfdelingId", "AfdelingId", medewerker.AfdelingId);
            return View(medewerker);
        }

        // POST: Medewerker/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MedewerkerId,Naam,Voornaam,Email,AfdelingId")] Medewerker medewerker)
        {
            if (id != medewerker.MedewerkerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medewerker);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedewerkerExists(medewerker.MedewerkerId))
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
            ViewData["AfdelingId"] = new SelectList(_context.Afdeling, "AfdelingId", "AfdelingId", medewerker.AfdelingId);
            return View(medewerker);
        }

        // GET: Medewerker/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medewerker == null)
            {
                return NotFound();
            }

            var medewerker = await _context.Medewerker
                .Include(m => m.Afdeling)
                .FirstOrDefaultAsync(m => m.MedewerkerId == id);
            if (medewerker == null)
            {
                return NotFound();
            }

            return View(medewerker);
        }

        // POST: Medewerker/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medewerker == null)
            {
                return Problem("Entity set 'TagHelperDbContext.Medewerker'  is null.");
            }
            var medewerker = await _context.Medewerker.FindAsync(id);
            if (medewerker != null)
            {
                _context.Medewerker.Remove(medewerker);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedewerkerExists(int id)
        {
          return (_context.Medewerker?.Any(e => e.MedewerkerId == id)).GetValueOrDefault();
        }
    }
}
