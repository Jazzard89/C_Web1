using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGroentenEnFruit2023.Models
{
    public class Orderlijn
    {
        public int OrderLijnId { get; set; }
        public int? AankoopOrderId { get; set; } 

        public AankoopOrder? AankoopOrder { get; set; } 
        // voor foreign keys te leggen (dit is een verwijzing naar aankoop order
        public int ArtikelId { get; set; }
        public Artikel? Artikel { get; set; } 
        // voor foreign keys te leggen
        public int Aantal { get; set; }
    }
}
