namespace MvcGroentenEnFruit2024_Jasper_Orens.Models
{
    public class OrderLijn
    {
        public int OrderLijnId { get; set; }
        public int AankoopOrderId { get; set; }
        public AankoopOrder? AankoopOrder { get; set; }
        public int ArtikelId { get; set; }
        public Artikel? Artikel { get; set; }
        public int Aantal { get; set; }
    }
}
