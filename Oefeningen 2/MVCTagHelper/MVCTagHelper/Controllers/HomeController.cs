using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTagHelper.Data;
using MVCTagHelper.Models;
using MVCTagHelper.ViewModels;
using System.Diagnostics;

namespace MVCTagHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TagHelperDbContext _context;

        public HomeController(ILogger<HomeController> logger, TagHelperDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Afdeling> afdelingen = _context.Afdeling.ToList();
            OverviewCard overviewCard = new OverviewCard(afdelingen);

            overviewCard.MedewerkerCards = afdelingen
                .Select(afdeling => GetOrCreateMedewerkerCard(afdeling))
                .ToList();

            return View(overviewCard);
        }

        private MedewerkerCard GetOrCreateMedewerkerCard(Afdeling afdeling)
        {
            Medewerker sampleMedewerker = _context.Medewerker.FirstOrDefault(m => m.AfdelingId == afdeling.AfdelingId);

            if (sampleMedewerker != null)
            {
                MedewerkerCard medewerkerCard = new MedewerkerCard(sampleMedewerker);

                return medewerkerCard;
            }
            else
            {
                return null;
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}