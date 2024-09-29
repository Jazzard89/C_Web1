using System.ComponentModel.DataAnnotations;

namespace MVCTagHelper.Models
{
    public class Afdeling
    {
        [Key]
        public int AfdelingId { get; set; }
        public string AfdelingNaam { get; set; }
        public int LocatieId { get; set; }
        public Locatie? Locatie { get; set; }
        public ICollection<Medewerker>? Medewerker { get; set; }
    }
}
