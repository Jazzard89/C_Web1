using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oefening1Klanten.Pages
{
    public class NieuweKlantModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            string name = Request.Form["Naam"];
            Data.Databank.AddClient(name);
            return RedirectToPage("Klant");
        }
    }
}
