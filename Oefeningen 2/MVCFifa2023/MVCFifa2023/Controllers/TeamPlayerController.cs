using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCFifa2023.Data;
using MVCFifa2023.Models;

namespace MVCFifa2023.Controllers
{
    public class TeamPlayerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeamPlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.TeamPlayers != null ? 
                          View(await _context.TeamPlayers.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TeamPlayer'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TeamPlayers == null)
            {
                return NotFound();
            }

            var teamPlayer = await _context.TeamPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamPlayer == null)
            {
                return NotFound();
            }

            return View(teamPlayer);
        }

        // GET: TeamPlayer/Create
        public IActionResult Create()
        {
            ViewBag.Teams = _context.Teams;
            ViewBag.Players = _context.Players;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamId,PlayerId,StartDate,EndDate")] TeamPlayer teamPlayer)
        {
            ViewBag.Teams = _context.Teams;
            ViewBag.Players = _context.Players;

            if (ModelState.IsValid)
            {
                if (_context.Players.Where(x => x.PlayerId == teamPlayer.PlayerId).Count() == 0)
                {
                    ModelState.AddModelError("Error", "Er bestaat geen link tussen de playerId uit de 2 tabellen!");
                    return View(teamPlayer);
                }
                else if(_context.Teams.Where(x => x.TeamId == teamPlayer.TeamId).Count() == 0)
                {
                    ModelState.AddModelError("Error", "Er bestaat geen link tussen de teamId uit de 2 tabellen!");
                    return View(teamPlayer);
                }
                else
                {
                    _context.Add(teamPlayer);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(teamPlayer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TeamPlayers == null)
            {
                return NotFound();
            }

            var teamPlayer = await _context.TeamPlayers.FindAsync(id);
            if (teamPlayer == null)
            {
                return NotFound();
            }
            return View(teamPlayer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamId,PlayerId,StartDate,EndDate")] TeamPlayer teamPlayer)
        {
            if (id != teamPlayer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(teamPlayer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamPlayerExists(teamPlayer.Id))
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
            return View(teamPlayer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TeamPlayers == null)
            {
                return NotFound();
            }

            var teamPlayer = await _context.TeamPlayers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamPlayer == null)
            {
                return NotFound();
            }

            return View(teamPlayer);
        }

        // POST: TeamPlayer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TeamPlayers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TeamPlayer'  is null.");
            }
            var teamPlayer = await _context.TeamPlayers.FindAsync(id);
            if (teamPlayer != null)
            {
                _context.TeamPlayers.Remove(teamPlayer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamPlayerExists(int id)
        {
          return (_context.TeamPlayers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
