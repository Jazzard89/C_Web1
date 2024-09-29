namespace Oefening1Klanten.Data
{
    public class Locatie
    {
        public int LocatieId { get; set; }
        public string PostCode { get; set; }
        public string Gemeente { get; set; }
        public Locatie()
        {
            LocatieId = -1;
            PostCode = string.Empty;
            Gemeente = string.Empty;
        }

        public Locatie(int locatieId, string postCode, string gemeente)
        {
            LocatieId = locatieId;
            PostCode = postCode;
            Gemeente = gemeente;
        }
    }
}
