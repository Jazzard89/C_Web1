using System.ComponentModel.DataAnnotations;

namespace Slide23.Models.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [Required]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }


        public string? RoleId { get; set; }
    }
}
