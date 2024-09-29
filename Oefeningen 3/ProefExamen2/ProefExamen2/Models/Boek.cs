using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProefExamen2.CustomModelValidations;

namespace ProefExamen2.Models
{
    public class Boek
    {
        public int BoekId { get; set; }
        [Required]
        [StringLength(50)]
        [TitleValidation]
        public string? Titel { get; set; }
        [Required]
        [StringLength(50)]
        public string? Auteur { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0, 9999.99)]
        public decimal Prijs { get; set; }

        public string? Afbeelding { get; set; }

        public IEnumerable<BestellingsRegel>? BestellingsRegels { get; set; }
    }
}
