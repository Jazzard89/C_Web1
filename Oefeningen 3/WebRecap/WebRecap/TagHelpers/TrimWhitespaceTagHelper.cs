using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace YourNamespace.Helpers
{
    [HtmlTargetElement("tw")]
    public class TrimWhitespaceTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Suppress the output of the original tag
            output.TagName = null;

            // Retrieve the child content asynchronously
            var childContent = await output.GetChildContentAsync();

            // Get the content as a string
            var content = childContent.GetContent();

            // Trim the content
            var trimmedContent = content.Trim();

            // Set the trimmed content back to the output
            output.Content.SetHtmlContent(trimmedContent);
        }
    }
}
