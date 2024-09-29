using Microsoft.AspNetCore.Mvc;
using MVCTestEFCore.Data;

namespace MVCTestEFCore.Controllers
{
    public class FirstTableController : Controller
    {
        AppDbContext _context;
        public FirstTableController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.FirstTable);
        }
    }
}
