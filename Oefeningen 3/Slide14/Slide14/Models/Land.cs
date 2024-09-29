namespace Slide14.Models
{
    public class Land
    {
        public int LandId { get; set; }
        public string LandCode { get; set; }
        public string LandNaam { get; set;}
        public ICollection<Locatie>? Locaties { get; set; }
    }
}
