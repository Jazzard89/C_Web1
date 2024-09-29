using System.ComponentModel.DataAnnotations;
using ProefExamen2.CustomModelValidations;

namespace ProefExamen2.Models
{
    public class Bestelling
    {
        public int BestellingId { get; set; }
        [Required]
        [DateValidation]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? BestelDatum { get; set; }
        public string? IdentityUserId { get; set; }
        public int Status { get; set; } = 0;

        public IEnumerable<BestellingsRegel>? BesellingRegels { get; set; }
    }
}
