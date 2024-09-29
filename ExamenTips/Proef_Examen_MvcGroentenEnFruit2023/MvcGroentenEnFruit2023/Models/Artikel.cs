using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit2023.Models
{
    public class Artikel
    {
        public int ArtikelId { get; set; }
        [StringLength(50)]
        public string ArtikelNaam { get; set; }
        public ICollection<Orderlijn>? Orderlijns { get; set; } 
        // foreign keys naar order lijnen leggen
    }
}
