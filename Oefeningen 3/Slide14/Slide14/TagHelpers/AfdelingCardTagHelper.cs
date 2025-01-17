﻿using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Slide14.ViewModels;

namespace Slide14.TagHelpers
{
    [HtmlTargetElement(Attributes = "afdeling-card-view-model")]
    public class AfdelingCardTagHelper : TagHelper
    {
        public AfdelingCard AfdelingCardViewModel { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string content = $@"<div class='card'>";
            content += $@"<h4 class='card-title'>{AfdelingCardViewModel.AfdelingNaam}</h4>";

            content += $@"<p class='card-position'>{AfdelingCardViewModel.LandCode} - 
                    {AfdelingCardViewModel.Locatie}</p>";

            content += $@"<p class='card-description'>De afdeling {AfdelingCardViewModel.AfdelingNaam}
            ligt in {AfdelingCardViewModel.Land}.</p>";

            output.TagName = "div";
            output.Content.SetHtmlContent(content);
        }
    }
}
