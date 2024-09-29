using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit2024_2.Models
{
    public class Artikel
    {
        [Key]
        public int ArtikelId { get; set; }
        [StringLength(50)]
        public string? ArtikelNaam { get; set; }

        //Foreign keys
        public IEnumerable<OrderLijn>? OrderLijnen { get; set; }
    }
}
