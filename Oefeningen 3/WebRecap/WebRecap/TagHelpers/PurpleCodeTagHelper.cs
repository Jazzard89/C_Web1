using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebRecap.TagHelpers
{
    // You may need to install the Microsoft.AspNetCore.Razor.Runtime package into your project
    [HtmlTargetElement("purple-code")]
    public class PurpleCodeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Change the tag to a <p> tag
            output.TagName = "span";

            // Get the content inside the tag
            var content = output.GetChildContentAsync().Result.GetContent();

            // Set the style attribute with proper syntax
            output.Attributes.SetAttribute("style", "font-family: 'Cascadia Mono'; color: purple;");

            // Set the inner content
            output.Content.SetHtmlContent(content);
        }
    }
}
