using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace MVCSportStore.Models
{
    public class Product
    {
        public long? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? Price { get; set; }
        [Required]
        public string Category { get; set; }
        public decimal ProductPrice => (Price == null) ? 0 : (decimal)Price;

        public ICollection<ResellerStock>? ResellerStocks { get; set; }

        public Product()
        {

        }
        public Product(string[] data)
        {
            Name = data[0];
            Description = data[1];
            Category = data[2];
            Price = decimal.Parse(data[3]);
        }
    }
}
