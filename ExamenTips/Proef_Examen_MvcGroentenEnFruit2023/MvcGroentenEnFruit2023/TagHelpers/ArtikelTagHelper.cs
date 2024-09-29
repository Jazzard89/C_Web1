using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit2023.Data;
using MvcGroentenEnFruit2023.ViewModel;

namespace MvcGroentenEnFruit2023.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement(Attributes = "artikel-id")]
    public class ArtikelTagHelper : TagHelper
    {
        public GroentenEnFruitDbContext _context;
        UserManager<IdentityUser> _userManager;
        public ArtikelTagHelper(GroentenEnFruitDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public int ArtikelId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var artikel = _context.Artikels.Where(x => x.ArtikelId == ArtikelId).FirstOrDefault();

            string content = $@"<div class='card m-2 p-2' style='width: 18rem;'";
            content += $@"<div class='card-body'>";
            content += $@"<h5 class='card-title'>Artikel</h5>";
            content += $@"<h6 class='card-subtitle mb-2 text-muted'>{artikel.ArtikelNaam}</h6>";

            var orderlijnen = _context.Orderlijns.Include(x => x.AankoopOrder);
            var userids = orderlijnen.Select(x => x.AankoopOrder.IdentityUserId);
            List<string> emails = new List<string>();
            foreach (var userid in userids)
            {
                string email = _userManager.FindByIdAsync(userid).Result.Email;
                emails.Add(email);
            }

            foreach (var email in emails)
            {
                content += $@"<p class='card-text'>{email}</p>";
            }

            output.TagName = "div";
            output.Content.SetHtmlContent(content);


            

        }
    }
}
