using System.ComponentModel.DataAnnotations;

namespace MVCClientLocEFCore.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [Required]
        public int? LocationId { get; set; }
        [MaxLength(50)]
        [Required]
        public string? ClientName { get; set; }

        public ICollection<Location>? Location { get; set; }
    }
}
