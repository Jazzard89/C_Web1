using Oef4MvcClientLocation.Data;
using System.Collections.Generic;

namespace Oef4MvcClientLocation.Models
{
    public class ClientLocation
    {
        public string ClientName {get; set;}
        public string City { get; set;}



        public ClientLocation(string clientName, string city)
        {
            ClientName = clientName;
            City = city;
        }
        public ClientLocation()
        {

        }

        public static IEnumerable<ClientLocation> Overview
        {
            get
            {
                List<ClientLocation> lst = new List<ClientLocation>();

                foreach (Client client in Database.Clients)
                {
                    Location location = Database.Locations.FirstOrDefault
                        (l => l.LocationId == client.LocationId);

                    if (location != null)
                    {
                        ClientLocation clientLocation = new ClientLocation(client.ClientName.ToString(), location.City.ToString());
                        lst.Add(clientLocation);
                    }
                }

                return lst;
            }
        }
    }
}
