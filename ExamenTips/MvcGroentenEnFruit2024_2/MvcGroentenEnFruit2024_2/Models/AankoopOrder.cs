using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit2024_2.Models
{
    public class AankoopOrder
    {
        [Key]
        public int AankoopOrderId { get; set; }
        public DateTime AankoopDatum { get; set; }
        public string? IdentityUserId { get; set; }
        public int Status { get; set; } = 0;


        //foreign keys
        public IEnumerable<OrderLijn>? OrderLijnen { get; set; }
    }
}
