using System.ComponentModel.DataAnnotations;

namespace Slide8.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        [Required]
        public string TeamName { get; set; }
    }
}
