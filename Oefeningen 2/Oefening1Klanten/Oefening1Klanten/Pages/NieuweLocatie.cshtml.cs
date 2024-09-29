using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oefening1Klanten.Pages
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
            Data.Databank.AddLocation(postCode, city);
            return RedirectToPage("Locaties");
        }
    }
}
