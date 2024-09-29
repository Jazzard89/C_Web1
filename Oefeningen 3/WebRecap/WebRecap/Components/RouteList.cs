using Microsoft.AspNetCore.Mvc;
using WebRecap.Components;
using WebRecap.Data;

namespace WebRecap.Components
{
    public class RouteList : ViewComponent
    {
        private readonly IWebHostEnvironment _environment;
        public RouteList(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public IViewComponentResult Invoke()
        {
            var pathList = new PathList(_environment);
            if (PathList.AllRoutes.Count() == 0)
            {
                pathList.LoadAllRoutes();
            }
            return View(model:PathList.AllRoutes);
        }
    }
}

