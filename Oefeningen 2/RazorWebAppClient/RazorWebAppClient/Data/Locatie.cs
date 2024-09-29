namespace RazorWebAppClient.Data
{
    public class Locatie
    {
        public int LocatieID { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public Locatie()
        {
            LocatieID = -1;
            Postcode = string.Empty;
            Gemeente = string.Empty;
        }

        public Locatie(int locatieID, string postcode, string gemeente)
        {
            LocatieID = locatieID;
            Postcode = postcode;
            Gemeente = gemeente;
        }
    }
}
