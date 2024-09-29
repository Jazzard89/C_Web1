using Microsoft.AspNetCore.Mvc;
using Slide23.Data;
using Slide23.Models.ViewModels;

namespace Slide23.Controllers
{
    public class StockController : Controller
    {
        private readonly AppDbContext _context;
        public StockController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var lst = new List<StockViewModel>();
            foreach(var artikel in _context.Artikels)
            {
                var stock = new StockViewModel();
                stock.ArtikelId = artikel.ArtikelId;
                stock.ArtikelNaam = artikel.Naam;
                stock.Hoeveelheid = 0;
                lst.Add(stock);
            }
            return View(lst);
        }
    }
}
