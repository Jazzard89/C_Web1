using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MvcGroentenEnFruit2024_Jasper_Orens.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MvcGroentenEnFruit2024_Jasper_Orens.TagHelpers
{
    [HtmlTargetElement("artikel", Attributes = "artikel-id")]
    public class ArtikelTagHelper : TagHelper
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ArtikelTagHelper(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HtmlAttributeName("artikel-id")]
        public int ArtikelId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var card = await ArtikelCardAsync();
            output.TagName = "div";
            output.Content.SetHtmlContent(card);
        }

        private async Task<TagBuilder> ArtikelCardAsync()
        {
            var artikel = await _context.Artikels.FindAsync(ArtikelId);
            var orderlijnen = _context.OrderLijnen.Where(ol => ol.ArtikelId == ArtikelId).ToList();
            var userMails = new List<string>();

            foreach (var user in _userManager.Users.ToList())
            {
                var found = await _userManager.FindByEmailAsync(user.Email);
                if (found != null)
                {
                    userMails.Add(found.Email);
                }
            }

            var card = new TagBuilder("div");
            card.AddCssClass("card m-2 p-2");
            card.Attributes.Add("style", "width: 18rem;");

            var cardBody = new TagBuilder("div");
            cardBody.AddCssClass("card-body");

            var cardTitle = new TagBuilder("h5");
            cardTitle.AddCssClass("card-title");
            cardTitle.InnerHtml.Append("Artikel");

            var cardSubtitle = new TagBuilder("h6");
            cardSubtitle.AddCssClass("card-subtitle mb-2 text-muted");
            cardSubtitle.InnerHtml.Append(artikel.ArtikelNaam);

            var cardText = new TagBuilder("p");
            cardText.AddCssClass("card-text");
            foreach (var userMail in userMails)
            {
                cardText.InnerHtml.Append(userMail + " ");
            }

            card.InnerHtml.AppendHtml(cardBody);
            cardBody.InnerHtml.AppendHtml(cardTitle);
            cardBody.InnerHtml.AppendHtml(cardSubtitle);
            cardBody.InnerHtml.AppendHtml(cardText);

            return card;
        }
    }
}
