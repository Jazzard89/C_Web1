using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Slide2.Pages
{
    public class LocatieDetailsModel : PageModel
    {
        public int LocatieID { get; set; }
        public void OnGet(int id)
        {
            LocatieID = id;
        }

    }
}
