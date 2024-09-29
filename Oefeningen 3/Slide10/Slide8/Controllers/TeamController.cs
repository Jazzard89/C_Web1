using Microsoft.AspNetCore.Mvc;
using Slide8.Data;
using Slide8.Models;

namespace Slide8.Controllers
{
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        public TeamController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var team = _context.Team;
            return View(team);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var team = new Team();
            return View(team);
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (ModelState.IsValid)
            {
                _context.Team.Add(team);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(team);
        }
    }
}
