using Microsoft.AspNetCore.Mvc;
using Slide5.Data;
using Slide5.Models;

namespace Slide5.Controllers
{
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
            if (ModelState.IsValid)
            {
                if (g.Naam == null || g.Naam.Length < 2)
                {
                    ModelState.AddModelError("", "Naam is te kort");
                    return View("Index", g);
                }
                LocalData.Gastlijst.Add(g);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Index", g);
            }
        }
    }
}
