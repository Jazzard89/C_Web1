﻿using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Slide14.TagHelpers
{
    [HtmlTargetElement("bold")]
    public class BoldTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.SetHtmlContent("<b>");
            output.PostContent.SetHtmlContent("</b>");
        }
    }
}
