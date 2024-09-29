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
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IWebHostEnvironment _environment;

        public PlayerController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        public IActionResult Index()
        {
            var players = _context.Players;
            return View(players);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var player = new Player();
            ViewBag.Teams = _context.Teams;
            return View(player);
        }

        [HttpGet]
        public IActionResult Create2()
        {
            var player = new NewPlayer();
            ViewBag.Teams = _context.Teams;
            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                AddPlayer(player);
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }
        [HttpPost]
        public IActionResult Create2(NewPlayer player)
        {
            if (ModelState.IsValid)
            {
                AddNewPlayer(player);
                return RedirectToAction(nameof(Index));
            }
            return View(player);
        }

        public IActionResult Detail(int id) 
        {
            var player = _context.Players.Where(x => x.PlayerId == id).FirstOrDefault();
            var fileExist = false;
            if (player.ImageLink != null) 
            {
                var path = _environment.WebRootPath; 
                var file = Path.Combine($"{path}\\images", player.ImageLink);
                fileExist = System.IO.File.Exists(file);
            }
            ViewBag.FileExist = fileExist;
            return View(player); 
        }

        private void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

        private void AddNewPlayer(NewPlayer player)
        {
            int newId = 0;
            if (_context.Players.Count() == 0)
            {
                newId = 1;
            }
            else
            {
                newId = _context.Players.Count() + 1;
            }
            Player p = new Player();
            p.PlayerId = newId;
            p.FirstName = player.FirstName;
            p.LastName = player.LastName;
            p.ImageLink = player.ImageLink;
            _context.Players.Add(p);
            _context.SaveChanges();

            var tp = new TeamPlayer();
            tp.PlayerId = p.PlayerId;
            tp.TeamId = player.TeamId;
            tp.StartDate = DateTime.Now;
            tp.EndDate = DateTime.Now.AddMonths(3);
            _context.TeamPlayers.Add(tp);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult CreateImage()
        {
            var player = new Player();
            return View(player);
        }

        [HttpPost]
        public IActionResult CreateImage(int? id, string imageLink)
        {
            try
            {
                var player = _context.Players.FirstOrDefault(x => x.PlayerId == id);
                if (player != null)
                {
                    player.ImageLink = imageLink;
                    _context.Players.Update(player);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
