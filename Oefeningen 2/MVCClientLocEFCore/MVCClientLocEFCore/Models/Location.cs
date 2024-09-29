using System.ComponentModel.DataAnnotations;

namespace MVCClientLocEFCore.Models
{
    public class Location
    {
        [Key] 
        public int LocationId { get; set; }
        [StringLength(15)]
        [Required]
        public string? PostCode { get; set; }
        [StringLength(100)]
        [Required]
        public string? City { get; set; }

        public Client? Client { get; set; }
    }
}
