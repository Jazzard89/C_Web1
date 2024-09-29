using Microsoft.AspNetCore.Identity;

namespace MvcGroentenEnFruit2023.ViewModel
{
    public class RegisterViewModel : LoginViewModel
    {
        public string? RoleId { get; set; }
    }
}
