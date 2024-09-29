using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRecap.Models.ViewModels;

namespace WebRecap.Controllers
{
    public class TopicController : Controller
    {
        private IWebHostEnvironment _environment;
        private PagingInfo pageInfo = new PagingInfo();

        public TopicController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        #region Web1 
        public IActionResult LocalDatabank(int page)
        {
            SetPaging("LocalDatabank", page);
            return View($"LocalDatabank/Page{page}");
        }

        public IActionResult RequestForm(int page)
        {
            SetPaging("RequestForm", page);
            return View($"RequestForm/Page{page}");
        }

        public IActionResult TagHelpers(int page)
        {
            SetPaging("TagHelpers", page);
            return View($"TagHelpers/Page{page}");
        }
        public IActionResult ViewBagMethod(int page)
        {
            ViewBag.RandoInput = 45;
            SetPaging("ViewBagMethod", page);
            return View($"ViewBagMethod/Page{page}");
        }
        public IActionResult ViewDataMethod(int page)
        {
            ViewData["RandoInput"] = 119;
            SetPaging("ViewDataMethod", page);
            return View($"ViewDataMethod/Page{page}");
        }
        public IActionResult ViewModels(int page)
        {
            SetPaging("ViewModels", page);
            return View($"ViewModels/Page{page}");
        }
        public IActionResult SeedData(int page)
        {
            SetPaging("SeedData", page);
            return View($"SeedData/Page{page}");
        }
        public IActionResult DataAnnotations(int page)
        {
            SetPaging("DataAnnotations", page);
            return View($"DataAnnotations/Page{page}");
        }
        public IActionResult ViewComponents(int page)
        {
            SetPaging("ViewComponents", page);
            return View($"ViewComponents/Page{page}");
        }
        public IActionResult SelectListItems(int page)
        {
            SetPaging("SelectListItems", page);
            return View($"SelectListItems/Page{page}");
        }
        public IActionResult ModelValidations(int page)
        {
            SetPaging("ModelValidations", page);
            return View($"Modelvalidations/Page{page}");
        }
        public IActionResult DbContexts(int page)
        {
            SetPaging("DbContexts", page);
            return View($"DbContexts/Page{page}");
        }
        public IActionResult IWebHostEnvironments(int page)
        {
            SetPaging("IWebHostEnvironments", page);
            return View($"IWebHostEnvironments/Page{page}");
        }
        public IActionResult PartialViews(int page)
        {
            SetPaging("PartialViews", page);
            return View($"PartialViews/Page{page}");
        }
        public IActionResult Identitys(int page)
        {
            SetPaging("Identitys", page);
            return View($"Identitys/Page{page}");
        }
        public IActionResult SignInManager(int page)
        {
            SetPaging("SignInManager", page);
            return View($"SignInManager/Page{page}");
        }
        public IActionResult RoleManager(int page)
        {
            SetPaging("RoleManager", page);
            return View($"RoleManager/Page{page}");
        }
        public IActionResult UserManager(int page)
        {
            SetPaging("UserManager", page);
            return View($"UserManager/Page{page}");
        }
        public IActionResult SeedDataIdentity(int page)
        {
            SetPaging("SeedDataIdentity", page);
            return View($"SeedDataIdentity/Page{page}");
        }
        #endregion


        public IActionResult Services(int page)
        {
            SetPaging("Services", page);
            return View($"Services/Page{page}");
        }
        public IActionResult EndpointRouting(int page)
        {
            SetPaging("EndpointRouting", page);
            return View($"EndpointRouting/Page{page}");
        }
        public IActionResult EndpointRoutingCustomConstraint(int page)
        {
           SetPaging("EndpointRoutingCustomConstraint", page);
            return View($"EndpointRoutingCustomConstraint/Page{page}");
        }

        public IActionResult Duende(int page)
        {
            SetPaging("Duende", page);
            return View($"Duende/Page{page}");
        }

        public IActionResult Tokens(int page)
        {
            SetPaging("Tokens", page);
            return View($"Tokens/Page{page}");
        }
        public IActionResult APIs(int page)
        {
            SetPaging("APIs", page);
            return View($"APIs/Page{page}");
        }
        public IActionResult HttpClients(int page)
        {
            SetPaging("HttpClients", page);
            return View($"HttpClients/Page{page}");
        }

        public IActionResult BlazorComponent(int page)
        {
            SetPaging("BlazorComponent", page);
            return View($"BlazorComponent/Page{page}");
        }



        public void SetPaging(string action, int page)
        {
            var directoryPath = Path.Combine(_environment.WebRootPath, "..", "Views", "Topic", $"{action}");
            var files = Directory.GetFiles(directoryPath);

            pageInfo = new PagingInfo
            {
                TopicName = action,
                TotalPages = files.Length,
                CurrentPage = page
            };

            ViewData["PagingInfo"] = pageInfo;
        }

    }
}
