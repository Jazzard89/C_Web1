using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ProefExamen2.TagBuilders
{
    [HtmlTargetElement("boektitel", Attributes = "titel")]
    public class TitelTagHelper : TagHelper
    {
        public string? Titel { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";  // change the tag to a div
            output.Attributes.SetAttribute("class", "tooltip-container");
            output.Content.SetHtmlContent(Container());
        }

        private TagBuilder ToolTipContainer()
        {
            TagBuilder toolTainer = new TagBuilder("span");
            toolTainer.AddCssClass("tooltip-text");
            toolTainer.InnerHtml.Append(Titel);
            return toolTainer;
        }

        private TagBuilder Container()
        {
            TagBuilder container = new TagBuilder("h2");
            container.Attributes["style"] = "color: red; margin: 0;";

            string newTitel = Titel;
            if (newTitel.Length > 12)
            {
                newTitel = newTitel.Substring(0, 12) + "...";
            }
            container.InnerHtml.Append(newTitel);
            container.InnerHtml.AppendHtml(ToolTipContainer());

            return container;
        }
    }
}
