using System.ComponentModel.DataAnnotations;

namespace Slide8.Models
{
    public class TeamPlayer
    {
        [Key]
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
