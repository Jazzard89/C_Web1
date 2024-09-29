using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Slide5PartyInvites.Data;
using Slide5PartyInvites.Models;

namespace Slide5PartyInvites.Controllers
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
            LocalData.GastList.Add(g);
            return RedirectToAction("Index", "Home"); 
        }
    }
}
