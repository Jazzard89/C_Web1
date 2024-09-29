using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slide5.Data;
using Slide5.Models;

namespace Slide5.Controllers
{
    [Authorize]
    public class GastController : Controller
    {
        public IActionResult Index()
        {
            Gast g = new Gast();
            return View(g);
        }

        [HttpPost]
        public IActionResult Reservatie(Gast g)
        {
            LocalData.Gastlijst.Add(g);
            return RedirectToAction("Index", "Home"); 
        }
    }
}
