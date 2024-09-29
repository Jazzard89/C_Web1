using Microsoft.AspNetCore.Mvc;
using Samenvatting1.Data;

namespace Samenvatting1.Controllers
{
    public class LocationController : Controller
    {
        private readonly AppDbContext _context;
        public LocationController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Locations);
        }
    }
}
