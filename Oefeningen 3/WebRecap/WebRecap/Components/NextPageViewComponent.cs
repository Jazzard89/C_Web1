using Microsoft.AspNetCore.Mvc;
using WebRecap.Models.ViewModels;

namespace WebRecap.Components
{
    public class NextPageViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PagingInfo pages, bool? top)
        {
            var displayPagingINfo = new DisplayPagingInfo
            {
                PagingInfo = pages,
                Top = top ?? false
            };
            return View(displayPagingINfo);
        }
    }
}
