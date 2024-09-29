using System.ComponentModel.DataAnnotations;

namespace MVCFifa2023.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        [Required]
        public string? TeamName { get; set; }

        public ICollection<TeamPlayer>? TeamPlayers { get; set; }
    }
}