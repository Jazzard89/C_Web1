using System.ComponentModel.DataAnnotations;

namespace Slide5.Models
{
    public class Gast
    {
        [Key]
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public bool? Aanwezig { get; set; }
    }
}
