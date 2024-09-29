using System.ComponentModel.DataAnnotations;

namespace MVCClientLocEFCore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double? ProductPrice { get; set; }
    }
}
