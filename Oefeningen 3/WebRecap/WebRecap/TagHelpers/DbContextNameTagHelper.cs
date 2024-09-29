using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebRecap.TagHelpers
{
    [HtmlTargetElement("DbContextName")]
    public class DbContextNameTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "component";
            output.Attributes.SetAttribute("type", "typeof(WebRecap.Blazor.ModifyDbContextName)");
            output.Attributes.SetAttribute("render-mode", "Server");
        }
    }
}
