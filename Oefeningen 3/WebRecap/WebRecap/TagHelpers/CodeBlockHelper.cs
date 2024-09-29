using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebRecap.TagHelpers
{
    [HtmlTargetElement("code-block")]
    public class CodeBlockHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            // Combine all style attributes into a single assignment
            output.Attributes.SetAttribute("style", "background: white; font-family: 'Cascadia Mono'; padding: 10px;");

            // Asynchronously get the child content
            var childContent = await output.GetChildContentAsync();

            // Keywords to highlight
            var keywordsBlue = new string[] { 
                "public", "class", "int", "string", "get", "set", "new", "var", "void", "double", 
                "base", "private", "long", "namespace", "using", "true", "false", "readonly", "async", 
                "await", "null", "decimal", "interface", "typeof", "nameof", "bool", "string\\[\\]", 
                "override", "static", "byte", "const", "inject"};

            var keywordsCyan = new string[] { "JsonIgnore", "IEnumerable", "DbSet", "IActionResult", 
                "IServiceCollection", "IdentityDbContext", "IdentityUser", "IdentityRole", "SignInManager", 
                "UserManager", "HttpGet", "HttpPost", "ChallengeResult", "Task", "SignInResult", 
                "ExternalLoginInfo", "LoginProvider", "IdentityResult", "ControllerBase", "Exception", 
                "HttpPut", "HttpDelete", "DataType", "Column", "DateTime", "MaxLength", "Required", "Key", 
                "ForeignKey", "ICollection", "DbContextOptions", "Dictionary", "List", "ILogger", "RoleManager",
                "ControllerContext", "HttpContext", "HttpClient", "IHttpClientFactory", "HttpResponseMessage", 
                "SelectList", "StringLength", "AccountController", "Controller", "IFormFile", "IdentityRole",
                "ServiceProvider", "IWebHostEnvironment", "WebHostBuilderContext", "IConfigurationBuilder", 
                "ValidationAttribute", "ValidationResult", "ValidationContext", "NoSpecialCharacters", 
                "TagHelper", "TagHelperOutput", "TagHelperContext", "WebApplication", "FromBody",
                "StatusCodes", "Guid", "ApplicationUser", "JwtSecurityTokenHandler", "JwtSecurityToken",
                "Claim", "SigningCredentials", "SecurityAlgorithms", "ClaimsPrincipal", "JwtBearerDefaults",
            "TimeSpan", "SymmetricSecurityKey", "HtmlTargetElement", "ViewContext", "TagBuilder",
            "AccountController", "IViewComponentResult", "dddddd"};

            var keywordsPurple = new string[] { "return", "try", "catch", "throw", "asp-controller", 
                "asp-action" };
            var keywordsBrown = new string[] { "ToList\\(", "Index\\(", "Create\\(", "Invoke", "View\\(" };

            // Regex pattern to match the keywords
            var patternBlue = $@"\b({string.Join("|", keywordsBlue)})\b";
            var patternCyan = $@"\b({string.Join("|", keywordsCyan)})\b";
            var patternPurple = $@"\b({string.Join("|", keywordsPurple)})\b";
            var patternBrown = $@"\b({string.Join("|", keywordsBrown)})\b";

            // Replace keywords with <span> tags for highlighting
            var highlightedContentBrown = Regex.Replace(childContent.GetContent(), patternBrown, match => $"<span style=\"color: brown;\">{match.Value}</span>");
            var highlightedContentBlue = Regex.Replace(highlightedContentBrown, patternBlue, match => $"<span style=\"color: blue;\">{match.Value}</span>");
            var highlightedContentCyan = Regex.Replace(highlightedContentBlue, patternCyan, match => $"<span style=\"color: #2b91af;\">{match.Value}</span>");
            var highlightedContentPurple = Regex.Replace(highlightedContentCyan, patternPurple, match => $"<span style=\"color: purple;\">{match.Value}</span>");

            // Set the modified HTML content
            output.Content.SetHtmlContent(highlightedContentPurple); // Corrected final output
        }
    }
}
