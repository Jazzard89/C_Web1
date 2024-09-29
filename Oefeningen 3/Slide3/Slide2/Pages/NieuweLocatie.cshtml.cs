using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Slide2.Data;

namespace Slide2.Pages
{
    public class NieuweLocatieModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            string postCode = Request.Form["PostCode"];
            string city = Request.Form["Gemeente"];
            Databank.AddLocation(postCode, city);
            return RedirectToPage("Locaties");
        }
    }
}
