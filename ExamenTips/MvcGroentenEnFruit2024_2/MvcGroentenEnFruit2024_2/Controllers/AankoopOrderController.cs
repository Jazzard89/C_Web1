using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit2024_2.Data;
using MvcGroentenEnFruit2024_2.Data.DefaultData;
using MvcGroentenEnFruit2024_2.Models;
using MvcGroentenEnFruit2024_2.Models.ViewModels;

namespace MvcGroentenEnFruit2024_2.Controllers
{
    [Authorize(Roles = Roles.Aankoper)]
    public class AankoopOrderController : Controller
    {
        #region Constructor
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AppDbContext _context;

        public AankoopOrderController(AppDbContext context, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _context = context;
        }
        #endregion

        #region Index
        public async Task<IActionResult> Index()
        {
            return _context.AankoopOrders != null ?
                        View(await _context.AankoopOrders.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.AankoopOrders'  is null.");
        }
        #endregion

        #region Detail
        // GET: AankoopOrder/Details/5
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
        #endregion

        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Artikelen = new SelectList(_context.Artikels, "ArtikelId", "ArtikelNaam");
            var user = await _signInManager.UserManager.GetUserAsync(User);
            var model = new AankoopOrderViewModel()
            {
                AankoopOrder = new AankoopOrder()
                {
                    IdentityUserId = user.Id,
                    AankoopDatum = DateTime.Now.Date
                },
                OrderLijn = new OrderLijn()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(AankoopOrderViewModel model)
        {
            // Ensure ViewBag.Artikelen is set again as the view might need this in case of errors
            ViewBag.Artikelen = new SelectList(_context.Artikels, "ArtikelId", "ArtikelNaam");
            var user = await _signInManager.UserManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                // Initialize `AankoopOrder` if it's null
                if (model.AankoopOrder == null)
                {
                    model.AankoopOrder = new AankoopOrder
                    {
                        AankoopDatum = DateTime.Now.Date,
                        IdentityUserId = user.Id 
                    };
                }

                // Initialize `OrderLijn` if it's null
                if (model.OrderLijn == null)
                {
                    model.OrderLijn = new OrderLijn();
                }

                if (model.OrderLijn.Aantal > 0)
                {
                    AankoopOrder aankoopOrder = model.AankoopOrder;
                    OrderLijn orderLijn = model.OrderLijn;

                    // Ensure the foreign key `AankoopOrderId` is properly set
                    orderLijn.AankoopOrder = aankoopOrder;

                    // Add objects to the database context
                    _context.AankoopOrders.Add(aankoopOrder);
                    _context.OrderLijnen.Add(orderLijn);

                    // Save changes to the database
                    _context.SaveChanges();

                    // Redirect to the Index action
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // Add a model error if the number is not valid
                    ModelState.AddModelError("", "Gelieve een aantal hoger dan 0 in te geven.");
                }
            }

            // If we reach here, something failed, return the view with the model
            return View(model);
        }

        #endregion

        #region Edit

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

        #endregion


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
