using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Oefening1Klanten.Pages
{
    public class LocatieDetailsModel : PageModel
    {
        public int LocatieId { get; set; }
        public void OnGet(int id)
        {
            LocatieId = id;
        }
    }
}
