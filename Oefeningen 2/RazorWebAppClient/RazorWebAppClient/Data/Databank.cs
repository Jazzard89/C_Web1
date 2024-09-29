namespace RazorWebAppClient.Data
{
    public class Databank
    {
        public static List<Klant> Klanten { get; set; }
        public static List<Locatie> Locaties { get; set; }
        public static void StartDatabank()
        {
            Klanten = new List<Klant>();
            Locaties = new List<Locatie>();
            Klanten.Add(new Klant(1, "Klant A"));
            Klanten.Add(new Klant(2, "Klant B"));
            Locaties.Add(new Locatie(1, "3500", "Hasselt"));
            Locaties.Add(new Locatie(2, "3600", "Genk"));
        }
        public static void AddLocation(string postCode, string city)
        {
            int id = Locaties.Max(x => x.LocatieID) + 1;
            Locaties.Add(new Locatie(id, postCode, city));
        }
    }
}
