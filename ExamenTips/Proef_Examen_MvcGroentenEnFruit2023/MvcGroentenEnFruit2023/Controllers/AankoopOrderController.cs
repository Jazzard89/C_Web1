using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcGroentenEnFruit2023.Data;
using MvcGroentenEnFruit2023.Data.DefaultData;
using MvcGroentenEnFruit2023.Models;

namespace MvcGroentenEnFruit2023.Controllers
{
    [Authorize(Roles = Roles.Aankoper)]
    public class AankoopOrderController : Controller

    {
        GroentenEnFruitDbContext _context;
        UserManager<IdentityUser> _userManager;
        public AankoopOrderController(GroentenEnFruitDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = Roles.Aankoper)]
        public IActionResult Index()
        {
            return View(_context.AankoopOrders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Artikels"] = new SelectList(_context.Artikels, "ArtikelId", "ArtikelNaam");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Orderlijn orderlijn)
        {

           _context.Orderlijns.Add(orderlijn);
            _context.AankoopOrders.Add(orderlijn.AankoopOrder);
            _context.SaveChanges();
            return View();
        }
    }
}
