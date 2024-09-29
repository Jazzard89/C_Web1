using Microsoft.AspNetCore.Identity;

namespace Slide23.Models.ViewModels
{
    public class IdentityViewModel
    {
        public IEnumerable<IdentityUser>? Users { get; set; }
        public IEnumerable<IdentityRole>? Roles { get; set; }
    }
}
