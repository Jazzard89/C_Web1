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

namespace ProefExamen2.Controllers
{
    public class BoekController : Controller
    {
        #region Constructor
        private readonly AppDbContext _context;
        private IWebHostEnvironment _environment;

        public BoekController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index()
        {
            return _context.Boeken != null ?
                        View(await _context.Boeken.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.Boeken'  is null.");
        }
        #endregion

        #region Details
        // GET: Boek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Boeken == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeken
                .FirstOrDefaultAsync(m => m.BoekId == id);
            if (boek == null)
            {
                return NotFound();
            }

            return View(boek);
        }

        [Authorize(Roles = Roles.Beheerder + "," + Roles.Administator)]
        #endregion

        #region Create
        [Authorize(Roles = Roles.Beheerder + "," + Roles.Administator)]
        public IActionResult Create()
        {
            Boek boek = new Boek();
            return View(boek);
        }

        [Authorize(Roles = Roles.Beheerder + "," + Roles.Administator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Boek boek, IFormFile afbeelding)
        {
            if (ModelState.IsValid)
            {
                if (afbeelding != null && afbeelding.Length > 0)
                {
                    string uploadFolder = Path.Combine(_environment.WebRootPath, "Afbeelding");
                    string filePath = Path.Combine(uploadFolder, boek.Titel + ".jpg");
                    
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await afbeelding.CopyToAsync(fileStream);
                    }

                    _context.Boeken.Add(boek);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(boek);
        }
        #endregion

        #region Edit
        [Authorize(Roles = Roles.Beheerder + "," + Roles.Administator)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Boeken == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeken.FindAsync(id);
            if (boek == null)
            {
                return NotFound();
            }
            return View(boek);
        }

        [Authorize(Roles = Roles.Beheerder + "," + Roles.Administator)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BoekId,Titel,Auteur,Prijs")] Boek boek)
        {
            if (id != boek.BoekId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoekExists(boek.BoekId))
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
            return View(boek);
        }

        #endregion

        #region Delete
        [Authorize(Roles = Roles.Beheerder + "," + Roles.Administator)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Boeken == null)
            {
                return NotFound();
            }

            var boek = await _context.Boeken
                .FirstOrDefaultAsync(m => m.BoekId == id);
            if (boek == null)
            {
                return NotFound();
            }

            return View(boek);
        }

        [Authorize(Roles = Roles.Beheerder + "," + Roles.Administator)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Boeken == null)
            {
                return Problem("Entity set 'AppDbContext.Boeken'  is null.");
            }
            var boek = await _context.Boeken.FindAsync(id);
            if (boek != null)
            {
                _context.Boeken.Remove(boek);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion

        private bool BoekExists(int id)
        {
          return (_context.Boeken?.Any(e => e.BoekId == id)).GetValueOrDefault();
        }
    }
}
