using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slide12.Models
{
    public class ResellerStock
    {
        [Key]
        public int ResellerStockId { get; set; }
        [Required]
        [ForeignKey("Reseller")]
        public int ResellerId { get; set; }
        public Reseller? Reseller { get; set; }
        [Required]
        [ForeignKey("Product")]
        public long? ProductId { get; set; }
        public Product? Product { get; set; }
        public int Amount { get; set; }

    }
}
