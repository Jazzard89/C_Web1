using System.ComponentModel.DataAnnotations;

namespace MVCSportStore.Models
{
    public class ResellerStock
    {
        [Key]
        public int ResellerStockId { get; set; }
        public int? ResellerId { get; set; }
        public long? ProductId { get; set; }
        public int Amount { get; set; }

        public string? ResellerGuid { get; set; }

        public Product? Product { get; set;}
        public Reseller? Reseller { get; set; }
    }
}
