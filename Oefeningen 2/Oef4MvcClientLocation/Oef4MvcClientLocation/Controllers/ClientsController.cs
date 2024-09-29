using Microsoft.AspNetCore.Mvc;
using Oef4MvcClientLocation.Data;
using Oef4MvcClientLocation.Models;
using System.Linq;
using System.Net.Sockets;

namespace Oef4MvcClientLocation.Controllers
{
    public class ClientsController : Controller
    {
        public IActionResult Index(List<Client> list)
        {
            return View(list);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var client = new Client();
            return View(client);
        }

        //Without CustomModelValdation
        //[HttpPost]
        //public IActionResult Create(string clientId, string locationId, string clientName)
        //{
        //    Client theClient = null;
        //    if (ModelState.IsValid)
        //    {
        //        if ((Client.Clients.Any(c => c.ClientId == int.Parse(clientId))) || int.Parse(clientId) < 1)
        //        {
        //            ModelState.AddModelError("ClientId", "Id bestaat al!");
        //            return View();
        //        }
        //        else
        //        {
        //            theClient = new Client(int.Parse(clientId), int.Parse(locationId), clientName);
        //            Database.Clients.Add(theClient);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    return View(theClient);
        //}

            [HttpPost]
            public IActionResult Create(Client client)
            {
                if (ModelState.IsValid)
                {
                        Database.Clients.Add(client);
                        return RedirectToAction("Index");
                }
                return View(client);
            }
        
    }
}


