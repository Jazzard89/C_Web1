using System.ComponentModel.DataAnnotations;

namespace ProefExamen2.Models
{
    public class BestellingsRegel
    {
        [Key]
        public int? BestellingsRegelId { get; set; }
        public int? BestellingId { get; set; }
        public Bestelling? Bestelling { get; set; }
        public int? BoekId { get; set; }
        public Boek? Boek { get; set; }
        public int? Aantal { get; set; }
    }
}
