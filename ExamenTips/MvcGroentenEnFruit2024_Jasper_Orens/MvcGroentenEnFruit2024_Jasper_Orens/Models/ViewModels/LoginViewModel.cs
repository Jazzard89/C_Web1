using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit2024_Jasper_Orens.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool? RememberMe { get; set; } = false;
    }
}
