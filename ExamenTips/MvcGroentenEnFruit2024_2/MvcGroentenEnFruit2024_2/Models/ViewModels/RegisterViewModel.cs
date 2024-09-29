using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit2024_2.Models.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ComfirmPassword { get; set; }
        public string? RoleId { get; set; }
    }
}
