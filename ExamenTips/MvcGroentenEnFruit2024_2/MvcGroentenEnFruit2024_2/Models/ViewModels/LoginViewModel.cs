using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace MvcGroentenEnFruit2024_2.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
