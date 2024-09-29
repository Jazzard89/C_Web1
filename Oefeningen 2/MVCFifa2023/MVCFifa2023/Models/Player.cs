using System.ComponentModel.DataAnnotations;

namespace MVCFifa2023.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set;}
        public string? ImageLink { get; set; }

        //ForeginKey
        public ICollection<TeamPlayer>? TeamPlayers { get; set; }
    }
}
