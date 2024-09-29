using System.ComponentModel.DataAnnotations;

namespace Slide5PartyInvites.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage="Passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
