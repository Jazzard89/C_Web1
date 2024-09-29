using System.ComponentModel.DataAnnotations;

namespace MvcGroentenEnFruit2024_Jasper_Orens.Models
{
    public class AankoopOrder
    {
        public int AankoopOrderId { get; set; }
        [DataType(DataType.Date)]
        public DateTime AankoopDatum { get; set; }
        public string IdentityUserId { get; set; }
        [Range(0, 1)]
        public double Status { get; set; } = 0;

        public IEnumerable<OrderLijn>? OrderLijnen { get; set; }
    }
}
