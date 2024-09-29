using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebRecap.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("openblock")]
    public class OpenBlockTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";


            // Get the content inside the tag
            var content = output.GetChildContentAsync().Result.GetContent();

            // Set the style attribute with proper syntax
            output.Attributes.SetAttribute("style", "margin-left: 50px;");

            // Set the inner content
            output.Content.SetHtmlContent(content);
        }
    }
}
