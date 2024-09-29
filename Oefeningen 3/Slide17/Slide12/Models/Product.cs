using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Slide12.Models
{
    public class Product
    {
        public Product() { }
        public Product(string[] data)
        {
            Name = data[0];
            Description = data[1];
            Category = data[2];
            Price = decimal.Parse(data[3]);
        }
        [Key]
        public long? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? Price { get; set; }
        [Required]
        public string Category { get; set; }
        //what is the use of ProductPrice and it's function?

        public decimal ProductPrice => (Price == null) ? 0 : (decimal)Price;


        public IEnumerable<ResellerStock>? Stocks { get; set; }
    }
}
