using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit2024_2.Models
{
    public class OrderLijn
    {
        [Key]
        public int OrderLijnId { get; set; }
        public int? AankoopOrderId { get; set; }
        public int? ArtikelId { get; set; }
        public int? Aantal { get; set; }

        //foreign keys
        public AankoopOrder? AankoopOrder { get; set; }
        public Artikel? Artikel { get; set; }
    }
}
