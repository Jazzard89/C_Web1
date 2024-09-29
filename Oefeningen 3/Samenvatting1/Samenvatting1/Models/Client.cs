using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Samenvatting1.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location? Location { get; set; }

        public Client() { }
        public Client(string? name, string? lastName, int locationId)
        {
            Name = name;
            LastName = lastName;
            LocationId = locationId;
        }
    }
}
