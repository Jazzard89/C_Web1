using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebRecap.Components
{
    public class DisplayObjectNameViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string objectVM)
        {
            if (string.IsNullOrEmpty(objectVM))
            {
                throw new ArgumentException("objectVM cannot be null or empty.");
            }

            var model = new StyleObjectViewModel();

            switch (objectVM)
            {
                case "solutionModel":
                    model.ObjectName = "SolutionName";
                    model.NoStyle = false;
                    break;
                case "solutionModel2":
                    model.ObjectName = "SolutionName";
                    model.NoStyle = true;
                    break;
                case "dbModel":
                    model.ObjectName = "DbContextName";
                    model.NoStyle = false;
                    break;
                case "dbModel2":
                    model.ObjectName = "DbContextName";
                    model.NoStyle = true;
                    break;
                case "dbmodel":
                    model.ObjectName = "DbContextname";
                    model.NoStyle = false;
                    break;
                case "dbmodel2":
                    model.ObjectName = "DbContextname";
                    model.NoStyle = true;
                    break;
                case "razorPageModel":
                    model.ObjectName = "RazorPageName";
                    model.NoStyle = false;
                    break;
                case "razorPageModel2":
                    model.ObjectName = "RazorPageName";
                    model.NoStyle = true;
                    break;
                case "modelModel":
                    model.ObjectName = "ModelName";
                    model.NoStyle = false;
                    break;
                case "modelModel2":
                    model.ObjectName = "ModelName";
                    model.NoStyle = true;
                    break;
                default:
                    model.ObjectName = "Unknown";
                    model.NoStyle = true;
                    break;
            }

            return View(model);
        }
    }
    public class StyleObjectViewModel2
    {
        public bool NoStyle { get; set; }
        public string ObjectName { get; set; }
    }
}
