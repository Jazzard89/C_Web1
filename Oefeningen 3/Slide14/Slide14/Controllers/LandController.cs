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
    public class LandController : Controller
    {
        private readonly AppDbContext _context;

        public LandController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Land
        public IActionResult Index()
        {
            return View(_context.landen) ;
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.landen == null)
            {
                return NotFound();
            }

            var land = await _context.landen
                .FirstOrDefaultAsync(m => m.LandId == id);
            if (land == null)
            {
                return NotFound();
            }

            return View(land);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var land = new Land();
            return View(land);
        }


        [HttpPost]
        public IActionResult Create(Land land)
        {
            if (ModelState.IsValid)
            {
                _context.Add(land);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(land);
        }

        // GET: Land/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.landen == null)
            {
                return NotFound();
            }

            var land = await _context.landen.FindAsync(id);
            if (land == null)
            {
                return NotFound();
            }
            return View(land);
        }

        // POST: Land/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LandId,LandCode,LandNaam")] Land land)
        {
            if (id != land.LandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(land);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LandExists(land.LandId))
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
            return View(land);
        }

        // GET: Land/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.landen == null)
            {
                return NotFound();
            }

            var land = await _context.landen
                .FirstOrDefaultAsync(m => m.LandId == id);
            if (land == null)
            {
                return NotFound();
            }

            return View(land);
        }

        // POST: Land/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.landen == null)
            {
                return Problem("Entity set 'AppDbContext.landen'  is null.");
            }
            var land = await _context.landen.FindAsync(id);
            if (land != null)
            {
                _context.landen.Remove(land);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LandExists(int id)
        {
          return (_context.landen?.Any(e => e.LandId == id)).GetValueOrDefault();
        }
    }
}
