namespace Oefening1Klanten.Data
{
    public class Databank
    {
        public static List<Klant> Klanten { get; set; }
        public static List<Locatie> Locaties { get; set; }
        public static void StartDatabank()
        {
            Klanten = new List<Klant>();
            Klanten.Add(new Klant(1, "Klant A"));
            Klanten.Add(new Klant(2, "Klant B"));

            Locaties = new List<Locatie>();
            Locaties.Add(new Locatie(1, "3500", "Hasselt"));
            Locaties.Add(new Locatie(2, "3600", "Genk"));
        }

        public static void AddLocation(string postCode, string city)
        {
            int id = Locaties.Max(x => x.LocatieId) + 1;
            Locaties.Add(new Locatie(id, postCode, city));
        }

        public static void AddClient(string name)
        {
            int id = Klanten.Max(x => x.KlantId) + 1;
            Klanten.Add(new Klant(id, name));
        }
    }
}
