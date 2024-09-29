using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorWebAppClient.Data;

namespace RazorWebAppClient.Pages
{
    public class SelecteerLocatieModel : PageModel
    {
        public void OnGet()
        {
        }
        public int LocatieId{ get; set; }
        public void OnGet(int id)
        {
            LocatieId = id;
        }
        public IActionResult OnPost()
        {
            var id = Request.Form["SelectLocatie"].FirstOrDefault();
            return RedirectToPage("LocatieDetails", new { id = int.Parse(id) });
        }
    }
}
