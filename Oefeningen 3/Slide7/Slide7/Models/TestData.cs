using Slide7.CustomModelValidations;
using System.ComponentModel.DataAnnotations;

namespace Slide7.Models
{
    public class TestData
    {
        public int? TestDataId { get; set; }
        [Required]
        [StringLength(10)]
        public string? Tekst { get; set; }
        [Required]
        [CustomDate]
        [DataType(DataType.Date)]
        public DateTime? Datum { get; set; }
    }
}
