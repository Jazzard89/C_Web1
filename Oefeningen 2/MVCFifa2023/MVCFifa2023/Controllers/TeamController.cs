using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCFifa2023.Data;
using MVCFifa2023.Models;

namespace MVCFifa2023.Controllers
{
    public class TeamController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TeamController(ApplicationDbContext context)
        {
            _context = context;
        }
        public ActionResult Index()
        {
            var teams = _context.Teams;
            return View(teams);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var team = new Team();
            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Team team)
        {
            if(ModelState.IsValid)
            {
                _context.Add(team);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(team);
            }
        }

        public IActionResult PlayerOverview(int id)
        {
            int currentYear = DateTime.Now.Year;
            DateTime goalDate = Convert.ToDateTime($"01/01/{currentYear}");
            var teamX = (from team in _context.Teams
                         where team.TeamId == id
                         select team).FirstOrDefault();
            ViewBag.Teams = teamX;

            var players = (from playerX in _context.TeamPlayers
                           from playerY in _context.Players
                          where playerX.TeamId == id
                          && playerY.PlayerId == playerX.PlayerId
                          && playerX.StartDate > goalDate
                           select playerY).ToList();

            return View(players);
        }
    }
}
