using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Slide18.Data;

namespace Slide18.Components
{
    public class HeaderMenuViewComponent : ViewComponent
    {
        AppDbContext _context;
        public HeaderMenuViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Voertuigen.Select(x => x.Merk).Distinct().OrderBy(x => x));
        }
    }
}
