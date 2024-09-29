using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCTagHelper.ViewModels;

namespace MVCTagHelper.TagHelpers
{
    [HtmlTargetElement(Attributes = "medewerker-card-view-model")]
    public class MedewerkerTagHelper : TagHelper
    {
        public MedewerkerCard MedewerkerCardViewModel { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = $@"<div class='card'>";
            content += $@"<p class='card-position'>{MedewerkerCardViewModel.Naam}</p>";
            content += $@"<p class='card-position'>{MedewerkerCardViewModel.Voornaam}</p>";
            content += $@"<p class='card-position'>{MedewerkerCardViewModel.Email}</p>";
            content += $@"<p class='card-position'>{MedewerkerCardViewModel.AfdelingId}</p>";

            output.TagName = "div";
            output.Content.SetHtmlContent(content);
        }
    }
}
