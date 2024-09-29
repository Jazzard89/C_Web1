using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProefExamen2.Data.DefaultData;
using ProefExamen2.Models.ViewModels;

namespace ProefExamen2.Controllers
{
    [Authorize(Roles = Roles.Administator)]
    public class IdentityController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public IdentityController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            List<string> roles = _roleManager.Roles.Select(r => r.Name).ToList();
            ViewBag.Roles = roles;
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            RoleViewModel model = new RoleViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task <IActionResult> CreateAsync(RoleViewModel model)
        {
            var result = !await _roleManager.RoleExistsAsync(model.RoleName);
            if (result)
            {
                var rolResult = await _roleManager.CreateAsync(new IdentityRole(model.RoleName));
                if (rolResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Role already exists");
                }
            }
            else
            {
                ModelState.AddModelError("", "an error occured");
            }
            return View(model.RoleName);
        }
    }
}
