using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit2023.Data;
using MvcGroentenEnFruit2023.Models;
using MvcGroentenEnFruit2023.ViewModel;
using static System.Formats.Asn1.AsnWriter;

namespace MvcGroentenEnFruit2023.Controllers
{
    public class ArtikelController : Controller
    {
        GroentenEnFruitDbContext _context;
        UserManager<IdentityUser> _userManager;

        public ArtikelController(GroentenEnFruitDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var Artikels = _context.Artikels;
            return View(Artikels);
        }

        public IActionResult Details(int id)
        {
            var artikel = _context.Artikels.Where(x => x.ArtikelId == id).FirstOrDefault();

            return View("Details", artikel);
        }
    }
}
