using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Slide18.TagHelpers
{
    [HtmlTargetElement("a", Attributes = "button-color")]
    public class HyperlinkButtonTagHelper : TagHelper
    {
        public string ButtonColor { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", $"btn btn-{ButtonColor}");
        }
    }
}
