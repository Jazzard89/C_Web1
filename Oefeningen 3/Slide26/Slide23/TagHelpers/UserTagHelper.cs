using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Slide23.TagHelpers
{
    [HtmlTargetElement("user")]
    public class UserTagHelper : TagHelper
    {
        UserManager<IdentityUser> _userManager;
        public UserTagHelper(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            var user = ViewContext.HttpContext.User;
            var identityUser = await _userManager.GetUserAsync(user);
            output.Content.SetHtmlContent(UserCard(identityUser));
        }

        private TagBuilder UserCard(IdentityUser user)
        {
            TagBuilder divCard = new TagBuilder("div");
            divCard.Attributes["class"] = "card";
            divCard.Attributes["style"] = "width: 18rem";

            //title
            divCard.InnerHtml.AppendHtml(UserCardTitle("Identity Card"));
            if (user != null)
            {
                //email
                divCard.InnerHtml.AppendHtml(UserCardItem("EMAIL", user.Email));
                //username
                divCard.InnerHtml.AppendHtml(UserCardItem("USERNAME", user.UserName));
            }
            return divCard;
        }
        private TagBuilder UserCardTitle(string title)
        {
            TagBuilder titleH5 = new TagBuilder("h5");

            titleH5.Attributes["class"] = "card-title";
            titleH5.InnerHtml.Append(title);

            return titleH5;
        }
        private TagBuilder UserCardItem(string header, string item)
        {
            TagBuilder cardItem = new TagBuilder("h6");

            cardItem.Attributes["class"] = "card-subtitle mb-2 text-muted p-2";
            cardItem.InnerHtml.Append(header);

            TagBuilder cardText = new TagBuilder("p");
            cardText.InnerHtml.Append(item);
            cardText.InnerHtml.AppendHtml(cardText);


            return cardItem;
        }
    }
}
