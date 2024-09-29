using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit2024_Jasper_Orens.Models
{
    public class Artikel
    {
        public int ArtikelId { get; set; }
        [Required]
        [StringLength(50)]
        public string ArtikelNaam { get; set; }

        public IEnumerable<OrderLijn>? OrderLijn { get; set; }


    }
}
