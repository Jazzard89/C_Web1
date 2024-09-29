using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Slide23.Data;
using Slide23.Data.DefaultData;
using Slide23.Models;

namespace Slide23.Controllers
{
    
    public class AankoopOrderController : Controller
    {
        private readonly AppDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;


        public AankoopOrderController(AppDbContext context, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        // GET: AankoopOrder
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.AankoopOrders.Include(a => a.Artikel).Include(a => a.IdentityUser);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AankoopOrder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AankoopOrders == null)
            {
                return NotFound();
            }

            var aankoopOrder = await _context.AankoopOrders
                .Include(a => a.Artikel)
                .Include(a => a.IdentityUser)
                .FirstOrDefaultAsync(m => m.AankoopOrderId == id);
            if (aankoopOrder == null)
            {
                return NotFound();
            }

            return View(aankoopOrder);
        }

        [Authorize(Roles = Roles.Aankoper)]
        public IActionResult Create()
        {
            ViewData["ArtikelId"] = new SelectList(_context.Artikels, "ArtikelId", "Naam");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View();
        }

        // POST: AankoopOrder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = Roles.Aankoper)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AankoopOrderId,ArtikelId,Hoeveelheid,IdentityUserId")] AankoopOrder aankoopOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aankoopOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtikelId"] = new SelectList(_context.Artikels, "ArtikelId", "ArtikelId", aankoopOrder.ArtikelId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", aankoopOrder.IdentityUserId);
            return View(aankoopOrder);
        }

        [Authorize(Roles = Roles.Aankoper)]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AankoopOrders == null)
            {
                return NotFound();
            }

            var aankoopOrder = await _context.AankoopOrders.FindAsync(id);
            if (aankoopOrder == null)
            {
                return NotFound();
            }
            ViewData["ArtikelId"] = new SelectList(_context.Artikels, "ArtikelId", "ArtikelId", aankoopOrder.ArtikelId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", aankoopOrder.IdentityUserId);
            return View(aankoopOrder);
        }

        // POST: AankoopOrder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AankoopOrderId,ArtikelId,Hoeveelheid,IdentityUserId")] AankoopOrder aankoopOrder)
        {
            if (id != aankoopOrder.AankoopOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aankoopOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AankoopOrderExists(aankoopOrder.AankoopOrderId))
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
            ViewData["ArtikelId"] = new SelectList(_context.Artikels, "ArtikelId", "ArtikelId", aankoopOrder.ArtikelId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", aankoopOrder.IdentityUserId);
            return View(aankoopOrder);
        }

        [Authorize(Roles = Roles.Aankoper)]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AankoopOrders == null)
            {
                return NotFound();
            }

            var aankoopOrder = await _context.AankoopOrders
                .Include(a => a.Artikel)
                .Include(a => a.IdentityUser)
                .FirstOrDefaultAsync(m => m.AankoopOrderId == id);
            if (aankoopOrder == null)
            {
                return NotFound();
            }

            return View(aankoopOrder);
        }

        // POST: AankoopOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AankoopOrders == null)
            {
                return Problem("Entity set 'AppDbContext.AankoopOrders'  is null.");
            }
            var aankoopOrder = await _context.AankoopOrders.FindAsync(id);
            if (aankoopOrder != null)
            {
                _context.AankoopOrders.Remove(aankoopOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AankoopOrderExists(int id)
        {
          return (_context.AankoopOrders?.Any(e => e.AankoopOrderId == id)).GetValueOrDefault();
        }
    }
}
