namespace Slide2.Data
{
    public class Locatie
    {
        public int LocatieID { get; set; }
        public int PostCode { get; set; }
        public string Gemeente { get; set; }
        public Locatie()
        {
        }
        public Locatie(int locatieID, int postCode, string gemeente)
        {
            LocatieID = locatieID;
            PostCode = postCode;
            Gemeente = gemeente;
        }
    }
}
