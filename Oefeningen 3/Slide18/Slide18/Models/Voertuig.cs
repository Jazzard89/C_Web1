using Slide18.ModelValidations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slide18.Models
{
    public class Voertuig
    {
        [Key]
        public int VoertuigId { get; set; }
        [Required]
        [StringLength(100)]
        public string Merk { get; set; }
        [Required]
        [StringLength(100)]
        public string MerkType { get; set; }
        [Required]
        [BouwjaarValidation]
        public int Bouwjaar { get; set; }
        [Required]
        [Range(0, 500000)]
        public int Km { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal VerkoopPrijs { get; set; }
        public bool AanwezigInShowroom { get; set; }
    }
}
