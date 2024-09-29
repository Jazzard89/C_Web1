using Microsoft.AspNetCore.Mvc;
using Slide12.ViewModels;

namespace Slide12.Controllers
{
    public class SettingsController : Controller
    {


        [HttpGet]
        public IActionResult PagingSettingsView()
        {
            PagingSettingViewModel paging = new PagingSettingViewModel();
            paging.ProductPagination = PagingSettings.ProductPagination;
            return View(paging);
        }
        [HttpPost]
        public IActionResult PagingSettingsView(PagingSettingViewModel paging)
        {
            PagingSettings.ProductPagination = paging.ProductPagination;
            return RedirectToAction("Index", "");
        }
    }
}
