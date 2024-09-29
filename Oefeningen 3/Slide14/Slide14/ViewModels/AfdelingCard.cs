using Slide14.Models;

namespace Slide14.ViewModels
{
    public class AfdelingCard
    {
        public int AfdelingId { get; set; }
        public string AfdelingNaam { get; set; }
        public string Locatie { get; set; }
        public string LandCode { get; set; }
        public string Land { get; set; }

        public Afdeling Afdeling { get; set; }

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
