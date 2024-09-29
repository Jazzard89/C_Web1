using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MVCSportStore.ViewModels;

namespace MVCSportStore.TagHelpers
{
    [HtmlTargetElement("page-link", Attributes = "paging-info")]
    public class PageLinkTagHelper : TagHelper
    {
        public PagingInfo PagingInfo { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Content.AppendHtml(GetPaginationLinks(PagingInfo));
        }
        private TagBuilder GetPaginationLink(int page, string category, bool active)
        {
            string pageLinkActive = "btn border border-primary m-1";
            string pageLink = "btn border border-secondary m-1";
            var li = new TagBuilder("li");
            li.Attributes["class"] = "page-item";

            //We bouwen de hyperlink
            var a = new TagBuilder("a");
            if (category == null)
            {
                a.Attributes["href"] = $"/Home/Index/{page}";
            }
            else
            {
                a.Attributes["href"] = $"/home/Index/{page}?category={category}";
            }
            a.Attributes["title"] = $"Click to go to page {page}"; 
            a.Attributes["class"] = (active) ? pageLinkActive : pageLink;
            a.InnerHtml.Append($"{page}");
            li.InnerHtml.AppendHtml(a); //voegen hyperlink toe tot list item
            return li;
        }
        private TagBuilder GetPaginationLinks(PagingInfo pagingInfo)
        {
            var ul = new TagBuilder("ul");
            ul.Attributes["class"] = "pagination";
            bool active = false;
            for (int page = 1; page <= pagingInfo.TotalPages; page++)
            {
                active = (page == PagingInfo.CurrentPage);
                ul.InnerHtml.AppendHtml(GetPaginationLink(page, PagingInfo.Category, active));
            }
            return ul;
        }

    }
}
