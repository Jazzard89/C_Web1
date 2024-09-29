using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slide9.Data;
using Slide9.Models;

namespace Slide9.Controllers
{
    public class LocationController : Controller
    {
        private readonly AppDbContext _context;
        public LocationController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Location location)
        {
            return View();
        }
    }
}
