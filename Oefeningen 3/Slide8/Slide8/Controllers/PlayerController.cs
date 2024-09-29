using Microsoft.AspNetCore.Mvc;
using Slide8.Data;
using Slide8.Models;

namespace Slide8.Controllers
{
    public class PlayerController : Controller
    {
        private readonly AppDbContext _context;
        public PlayerController(AppDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
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
            return View(player);
        }

        [HttpPost]
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Players.Add(player);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        public IActionResult Details(int id)
        {
            var player = _context.Players.Where(x => x.PlayerId == id).FirstOrDefault();
            return View(player);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var player = _context.Players.Where(x => x.PlayerId == id).FirstOrDefault();
            return View(player);
        }

        [HttpPost]
        public IActionResult Delete(Player player) 
        {
            _context.Players.Remove(player); 
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var player = _context.Players.Where(x => x.PlayerId == id).FirstOrDefault();
            return View(player);
        }

        [HttpPost]
        public IActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                _context.Players.Update(player);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
