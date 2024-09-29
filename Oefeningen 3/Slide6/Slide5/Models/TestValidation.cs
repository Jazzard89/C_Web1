using System.ComponentModel.DataAnnotations;

namespace Slide5.Models
{
    public class TestValidation
    {
        [Key]
        public int? TestValidationId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public DateTime? DateOfBirth { get; set; }
    }
}
