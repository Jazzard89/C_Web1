using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebRecap.TagHelpers
{
    [HtmlTargetElement("blue-code")]
    public class BlueCodeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Change the tag to a <p> tag
            output.TagName = "span";

            // Get the content inside the tag
            var content = output.GetChildContentAsync().Result.GetContent();

            // Set the style attribute with proper syntax
            output.Attributes.SetAttribute("style", "font-family: 'Cascadia Mono'; color: blue;");

            // Set the inner content
            output.Content.SetHtmlContent(content);
        }
    }
}
