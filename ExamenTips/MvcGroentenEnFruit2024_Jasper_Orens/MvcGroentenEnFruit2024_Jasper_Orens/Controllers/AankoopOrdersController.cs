using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit2024_Jasper_Orens.Data;
using MvcGroentenEnFruit2024_Jasper_Orens.Data.DefaultData;
using MvcGroentenEnFruit2024_Jasper_Orens.Models;
using MvcGroentenEnFruit2024_Jasper_Orens.Models.ViewModels;

namespace MvcGroentenEnFruit2024_Jasper_Orens.Controllers
{
    [Authorize(Roles = Roles.Aankoper)]
    public class AankoopOrdersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public AankoopOrdersController(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [Authorize(Roles = Roles.Aankoper)]
        public async Task<IActionResult> Index()
        {
              return _context.AankoopOrders != null ? 
                          View(await _context.AankoopOrders.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.AankoopOrders'  is null.");
        }

        // GET: AankoopOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AankoopOrders == null)
            {
                return NotFound();
            }

            var aankoopOrder = await _context.AankoopOrders
                .FirstOrDefaultAsync(m => m.AankoopOrderId == id);
            if (aankoopOrder == null)
            {
                return NotFound();
            }

            return View(aankoopOrder);
        }

        public IActionResult Create()
        {
            var artikelIds = _context.OrderLijnen.Select(x => new SelectListItem
            {
                Value = x.ArtikelId.ToString(),
                Text = x.Artikel.ArtikelNaam.ToString()
            }).ToList();

            ViewBag.OrderlijnenArtikelId = new SelectList(artikelIds, "Value", "Text");

            AankoopOrderViewModel aankoopOrderVM = new AankoopOrderViewModel
            {
                AankoopOrder = new AankoopOrder(),
                OrderLijn = new OrderLijn()
            };
            return View(aankoopOrderVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AankoopOrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.OrderLijn == null)
                {
                    ModelState.AddModelError(string.Empty, "OrderLijn cannot be null.");
                    return View(model);
                }

                if (model.AankoopOrder == null)
                {
                    ModelState.AddModelError(string.Empty, "AankoopOrder cannot be null.");
                    return View(model);
                }

                var newOrderLijn = new OrderLijn
                {
                    ArtikelId = model.OrderLijn.ArtikelId,
                    Aantal = model.OrderLijn.Aantal
                };

                var newAankoopOrder = new AankoopOrder
                {
                    AankoopDatum = DateTime.Now, 
                    IdentityUserId = _userManager.GetUserId(User), 
                    Status = 1,
                    OrderLijnen = new List<OrderLijn> { newOrderLijn }
                };

                _context.AankoopOrders.Add(newAankoopOrder);
                _context.OrderLijnen.Add(newOrderLijn);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var artikelIds = _context.OrderLijnen.Select(x => new SelectListItem
            {
                Value = x.ArtikelId.ToString(),
                Text = x.Artikel.ArtikelNaam.ToString()
            }).ToList();

            ViewBag.OrderlijnenArtikelId = new SelectList(artikelIds, "Value", "Text");

            return View(model);
        }



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
            return View(aankoopOrder);
        }

        // POST: AankoopOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AankoopOrderId,AankoopDatum,IdentityUserId,Status")] AankoopOrder aankoopOrder)
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
            return View(aankoopOrder);
        }

        // GET: AankoopOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AankoopOrders == null)
            {
                return NotFound();
            }

            var aankoopOrder = await _context.AankoopOrders
                .FirstOrDefaultAsync(m => m.AankoopOrderId == id);
            if (aankoopOrder == null)
            {
                return NotFound();
            }

            return View(aankoopOrder);
        }

        // POST: AankoopOrders/Delete/5
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
