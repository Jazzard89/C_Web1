using System.ComponentModel.DataAnnotations;

namespace Slide8.Models
{
    public class TeamPlayer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int? TeamId { get; set; }
        [Required]
        public int? PlayerId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public Team? Team { get; set; } //ICollection in deze class
        public Player? Player { get; set; } //ICollection in deze class
    }
}
