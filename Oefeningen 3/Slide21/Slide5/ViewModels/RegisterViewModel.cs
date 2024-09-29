using System.ComponentModel.DataAnnotations;

namespace Slide5.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
