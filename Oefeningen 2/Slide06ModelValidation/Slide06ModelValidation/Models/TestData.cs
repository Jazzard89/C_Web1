using Slide06ModelValidation.CustomModelValidations;
using System.ComponentModel.DataAnnotations;

namespace Slide06ModelValidation.Models
{
    public class TestData
    {
        public int? TestDataId { get; set; }
        [Required]
        [StringLength(10)]
        public string? Tekst { get; set; }
        [CustomDate]
        public DateTime? Datum { get; set; }
    }
}
