using Samenvatting1.Models;

namespace Samenvatting1.Data.SeedData
{
    public static class SeedData
    {
        private static IEnumerable<Job> Jobs => GetJobList();
        private static IEnumerable<Job> GetJobList()
        {
            List<Job> jobs = new List<Job>();
            jobs.Add(new Job(new string[] { "API", "Create an API for the client" }));
            jobs.Add(new Job(new string[] { "WebShop", "Create a webshop" }));
            jobs.Add(new Job(new string[] { "Single page Website", "Create a single paged website" }));
            jobs.Add(new Job(new string[] { "Multi page website", "Create a website with multiple pages" }));
            jobs.Add(new Job(new string[] { "Application", "Create a custom application" }));
            return jobs;
        }

        private static IEnumerable<Client> Clients => GetClientList();
        private static IEnumerable<Client> GetClientList()
        {
            List<Client> clients = new List<Client>();
            clients.Add(new Client("Jefrey", "Maltser", 1));
            clients.Add(new Client("Anna", "Buysen", 2));
            clients.Add(new Client("Philip", "Raven", 3));
            return clients;
        }

        private static IEnumerable<string> Locations => GetLocationList();
        private static IEnumerable<string> GetLocationList()
        {
            List<string> locations = new List<string>();
            locations.Add("3500;Hasselt");
            locations.Add("3600;Genk");
            locations.Add("3510;Kermt");
            return locations;
        }


        public static void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                //jobs
                if (!context.Jobs.Any())
                {
                    foreach (Job job in Jobs)
                    {
                        context.Jobs.Add(job);
                    }
                    context.SaveChanges();
                }
                //locations
                if (!context.Locations.Any())
                {
                    foreach (var locationString in Locations)
                    {
                        var location = new Location(locationString.Split(';'));
                        context.Locations.Add(location);
                    }
                    context.SaveChanges();
                }
                //clients
                if (!context.Clients.Any())
                {
                    foreach (Client client in Clients)
                    {
                        context.Clients.Add(client);
                    }
                    context.SaveChanges();
                }
            }
        }

    }
}
