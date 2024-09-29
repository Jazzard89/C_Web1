using Microsoft.AspNetCore.Mvc;
using Oef4MvcClientLocation.Data;
using Oef4MvcClientLocation.Models;

namespace Oef4MvcClientLocation.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index(List<Location> locations)
        {
            return View(locations);
        }

        //without CustomModelValidation
        //public IActionResult Create(string postCode, string city)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var locationId = (from l in Location.Locations
        //                          select l.LocationId).LastOrDefault() + 1;

        //        Database.Locations.Add(new Location(locationId, postCode, city));
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        [HttpGet]
        public IActionResult Create()
        {
            var location = new Location();
            return View(location);
        }

        [HttpPost]
        public IActionResult Create(Location location)
        {
            if (ModelState.IsValid)
            {
                var locationId = (from l in Location.Locations
                                  select l.LocationId).LastOrDefault() + 1;

                location.LocationId = locationId;

                Database.Locations.Add(location);
                return RedirectToAction("Index");
            }
            return View(location);
        }
    }
}
