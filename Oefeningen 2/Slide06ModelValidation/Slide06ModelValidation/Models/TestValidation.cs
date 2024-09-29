using System.ComponentModel.DataAnnotations;

namespace Slide06ModelValidation.Models
{
    public class TestValidation
    {
        [Key]
        public int? TestValidationId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
