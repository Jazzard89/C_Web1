using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCClientLocEFCore.Data;
using System.Linq;

namespace MVCClientLocEFCore.Controllers
{
    public class ClientLocationController : Controller
    {
        #region DbContext
        private ClientLocationContext _context;
        public ClientLocationController(ClientLocationContext context)
        {
            _context = context;
        }
        #endregion
        public ActionResult Index()
        {
            var clientLocations = (from c in _context.Client
                                  join l in _context.Location
                                  on c.LocationId equals l.LocationId
                                  select new { c, l }).ToList();

            ViewBag.ClientLocation = clientLocations;

            return View(clientLocations);
        }
    }
}
