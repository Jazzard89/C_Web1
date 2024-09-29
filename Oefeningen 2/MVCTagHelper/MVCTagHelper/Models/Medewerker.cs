using System.ComponentModel.DataAnnotations;

namespace MVCTagHelper.Models
{
    public class Medewerker
    {
        [Key]
        public int MedewerkerId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public int AfdelingId { get; set; }
        public Afdeling? Afdeling { get; set; }
    }
}
