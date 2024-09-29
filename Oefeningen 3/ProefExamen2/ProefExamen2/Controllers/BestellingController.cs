using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProefExamen2.Data;
using ProefExamen2.Data.DefaultData;
using ProefExamen2.Models;
using ProefExamen2.Models.ViewModels;

namespace ProefExamen2.Controllers
{
    [Authorize(Roles = Roles.Klant)]
    public class BestellingController : Controller
    {
        private readonly AppDbContext _context;

        public BestellingController(AppDbContext context)
        {
            _context = context;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.BestellingsRegels.Include(b => b.Bestelling).Include(b => b.Boek);
          
            return View(await appDbContext.ToListAsync());
        }
        #endregion

        #region Detail
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BestellingsRegels == null)
            {
                return NotFound();
            }

            var bestellingsRegel = await _context.BestellingsRegels
                .Include(b => b.Bestelling)
                .Include(b => b.Boek)
                .FirstOrDefaultAsync(m => m.BestellingsRegelId == id);
            if (bestellingsRegel == null)
            {
                return NotFound();
            }

            return View(bestellingsRegel);
        }

        #endregion

        #region Create
        public IActionResult Create()
        {
            ViewData["BestellingId"] = new SelectList(_context.Bestellingen, "BestellingId", "BestellingId");
            ViewData["BoekId"] = new SelectList(_context.Boeken, "BoekId", "Auteur");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BestellingsRegelId,BestellingId,BoekId,Aantal")] BestellingsRegel bestellingsRegel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bestellingsRegel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BestellingId"] = new SelectList(_context.Bestellingen, "BestellingId", "BestellingId", bestellingsRegel.BestellingId);
            ViewData["BoekId"] = new SelectList(_context.Boeken, "BoekId", "Auteur", bestellingsRegel.BoekId);
            return View(bestellingsRegel);
        }

        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BestellingsRegels == null)
            {
                return NotFound();
            }

            var bestellingsRegel = await _context.BestellingsRegels.FindAsync(id);
            if (bestellingsRegel == null)
            {
                return NotFound();
            }
            ViewData["BestellingId"] = new SelectList(_context.Bestellingen, "BestellingId", "BestellingId", bestellingsRegel.BestellingId);
            ViewData["BoekId"] = new SelectList(_context.Boeken, "BoekId", "Auteur", bestellingsRegel.BoekId);
            return View(bestellingsRegel);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("BestellingsRegelId,BestellingId,BoekId,Aantal")] BestellingsRegel bestellingsRegel)
        {
            if (id != bestellingsRegel.BestellingsRegelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bestellingsRegel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BestellingsRegelExists(bestellingsRegel.BestellingsRegelId))
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
            ViewData["BestellingId"] = new SelectList(_context.Bestellingen, "BestellingId", "BestellingId", bestellingsRegel.BestellingId);
            ViewData["BoekId"] = new SelectList(_context.Boeken, "BoekId", "Auteur", bestellingsRegel.BoekId);
            return View(bestellingsRegel);
        }

        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BestellingsRegels == null)
            {
                return NotFound();
            }

            var bestellingsRegel = await _context.BestellingsRegels
                .Include(b => b.Bestelling)
                .Include(b => b.Boek)
                .FirstOrDefaultAsync(m => m.BestellingsRegelId == id);
            if (bestellingsRegel == null)
            {
                return NotFound();
            }

            return View(bestellingsRegel);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.BestellingsRegels == null)
            {
                return Problem("Entity set 'AppDbContext.BestellingsRegels'  is null.");
            }
            var bestellingsRegel = await _context.BestellingsRegels.FindAsync(id);
            if (bestellingsRegel != null)
            {
                _context.BestellingsRegels.Remove(bestellingsRegel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        private bool BestellingsRegelExists(int? id)
        {
          return (_context.BestellingsRegels?.Any(e => e.BestellingsRegelId == id)).GetValueOrDefault();
        }
    }
}
