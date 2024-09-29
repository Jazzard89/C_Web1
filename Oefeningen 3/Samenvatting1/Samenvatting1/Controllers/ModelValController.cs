using Microsoft.AspNetCore.Mvc;
using Samenvatting1.Data;
using Samenvatting1.Models;

namespace Samenvatting1.Controllers
{
    public class ModelValController : Controller
    {
        public IActionResult Index()
        {
            return View(LocalData.ModelValClassList);
        }

        [HttpGet]
        public IActionResult Form()
        {
            var model = new ModelValClass();
            return View(model);
        }

        [HttpPost]
        public IActionResult Form(ModelValClass model)
        {
            if (ModelState.IsValid)
            {
                LocalData.ModelValClassList.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
