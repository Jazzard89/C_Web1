using System.ComponentModel.DataAnnotations;

namespace MVCFifa2023.Models
{
    public class TeamPlayer
    {
        public int Id { get; set; }
        [Required]
        public int TeamId { get; set; }
        [Required]
        public int PlayerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        //ForeignKey
        public Team? Team { get; set; }
        public Player? Player { get; set; }
    }
}
