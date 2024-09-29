using Oef4MvcClientLocation.Models;

namespace Oef4MvcClientLocation.Data
{
    public class Database
    {
        public static List<Client> Clients { get; set; }
        public static List<Location> Locations { get; set; }
        public static void StartDatabase()
        {
            Clients = new List<Client>()
            {
                new Client {ClientId = 1, LocationId = 1, ClientName = "Jefrey"},
                new Client {ClientId = 2, LocationId = 2, ClientName = "Paul"}
            };

            Locations = new List<Location>()
            {
                new Location {LocationId = 1, City = "Hasselt", PostCode = "3500"},
                new Location {LocationId = 2, City = "Genk", PostCode = "3600"}
            };
        }
        public static InsertResult AddClient(Client c)
        {
            try
            {
                Clients.Add(c);
                List<string> result = new List<string>();
                return new InsertResult{Succeeded = true, Errors = result};
            }
            catch(Exception ex)
            {
                List<string> result = new List<string>(); 
                result.Add(ex.Message);
                return new InsertResult { Succeeded = false, Errors = result };
            }
        }
        public static InsertResult AddLocation(Location l)
        {
            try
            {
                Locations.Add(l);
                List<string> result = new List<string>();
                return new InsertResult { Succeeded = true, Errors = result };
            }
            catch (Exception ex)
            {
                List<string> result = new List<string>();
                result.Add(ex.Message);
                return new InsertResult { Succeeded = false, Errors = result };
            }
        }
    }
}
