using Microsoft.AspNetCore.Mvc;
using Slide12.Data;

namespace Slide12.Controllers
{
    public class ResellerController : Controller
    {
        private readonly AppDbContext _context;
        public ResellerController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var resellers = _context.Resellers;
            return View(resellers);
        }
    }
}
