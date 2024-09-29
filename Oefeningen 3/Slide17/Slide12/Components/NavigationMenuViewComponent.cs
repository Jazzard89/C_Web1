using Microsoft.AspNetCore.Mvc;
using Slide12.Data;

namespace Slide12.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private AppDbContext _context;
        public NavigationMenuViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            return View(
                _context.Products.Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
