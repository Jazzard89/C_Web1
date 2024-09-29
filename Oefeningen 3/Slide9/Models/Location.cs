using System.ComponentModel.DataAnnotations;

namespace Slide9.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        [StringLength(15)]
        public string PostCode { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }
    }
}
