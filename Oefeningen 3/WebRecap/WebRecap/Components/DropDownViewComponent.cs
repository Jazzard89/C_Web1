using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using WebRecap.Models.ViewModels;

namespace WebRecap.Components
{
    public class DropDownViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string updateComp)
        {
            return View("Default", updateComp);
        }
    }
}
