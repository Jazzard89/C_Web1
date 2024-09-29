using MVCTagHelper.Models;

namespace MVCTagHelper.ViewModels
{
    public class MedewerkerCard
    {
        public Medewerker Medewerker { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public int AfdelingId { get; set; }

        public MedewerkerCard(Medewerker medewerker)
        {
            Medewerker = medewerker; 
            Naam = medewerker.Naam;
            Voornaam = medewerker.Voornaam;
            Email = medewerker.Email;
            AfdelingId = medewerker.AfdelingId;
        }
    }
}
