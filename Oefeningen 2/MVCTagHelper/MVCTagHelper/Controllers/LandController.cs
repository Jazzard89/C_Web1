using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCTagHelper.Data;
using MVCTagHelper.Models;

namespace MVCTagHelper.Controllers
{
    public class LandController : Controller
    {
        private TagHelperDbContext _dbContext;
        public LandController(TagHelperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ActionResult Index()
        {
            var land = _dbContext.Land;
            return View(land);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var land = new Land(); 
            return View(land);
        }


        [HttpPost]
        public ActionResult Create(Land land)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Land.Add(land);
                    _dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Invalid Data! ->" + ex.Message.Substring(50));
                }

            }
            return View();

        }

        
    }
}
