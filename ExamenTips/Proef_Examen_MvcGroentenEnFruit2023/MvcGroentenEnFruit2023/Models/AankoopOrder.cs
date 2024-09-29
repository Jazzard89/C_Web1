using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit2023.Models
{
    public class AankoopOrder
    {
        public int AankoopOrderId { get; set; }
        public string? AankoopDatum { get; set; }
        public string? IdentityUserId { get; set; }
        [Range(0, 1)]
        public int Status { get; set; }

        public ICollection<Orderlijn>? Orderlijns { get; set; } // voor foreign keys te leggen
    }
}
