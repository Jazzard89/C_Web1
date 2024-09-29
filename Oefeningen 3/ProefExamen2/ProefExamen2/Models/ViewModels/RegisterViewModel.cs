using ProefExamen2.Data.DefaultData;
using System.ComponentModel.DataAnnotations;

namespace ProefExamen2.Models.ViewModels
{
    public class RegisterViewModel : LoginViewModel
    {
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ComfirmPassword { get; set; }
        public string RoleId { get; set; }
    }
}
