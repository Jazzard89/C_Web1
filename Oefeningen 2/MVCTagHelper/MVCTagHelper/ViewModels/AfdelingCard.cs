using MVCTagHelper.Models;

namespace MVCTagHelper.ViewModels
{
    public class AfdelingCard
    {
        public Afdeling Afdeling { get; set; }
        public int AfdelingId { get; set; }
        public string AfdelingNaam { get; set; }
        public string Locatie { get; set; }
        public string LandCode { get; set; }
        public string Land { get; set; }
        public AfdelingCard(Afdeling afdeling)
        {
            AfdelingId = afdeling.AfdelingId;
            AfdelingNaam = afdeling.AfdelingNaam;
            Locatie = afdeling.Locatie.Stad;
            Land = afdeling.Locatie.Land.LandNaam;
            LandCode = afdeling.Locatie.Land.LandCode;
            Afdeling = afdeling;
        }
    }
}
