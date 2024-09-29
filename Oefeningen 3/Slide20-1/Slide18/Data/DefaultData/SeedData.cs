using Slide18.Models;

namespace Slide18.Data.DefaultData
{
    public static class SeedData
    {
        private static IEnumerable<Voertuig> Voertuigen => GetVoertuigen();

        private static IEnumerable<Voertuig> GetVoertuigen()
        {
            List<Voertuig> voertuigen = new List<Voertuig>();

            voertuigen.Add(new Voertuig()
            {
                Merk = "Toyota",
                MerkType = "Corolla",
                Bouwjaar = 2020,
                Km = 15000,
                VerkoopPrijs = 18500.00m,
                AanwezigInShowroom = true
            });

            voertuigen.Add(new Voertuig()
            {
                Merk = "Volkswagen",
                MerkType = "Golf",
                Bouwjaar = 2018,
                Km = 40000,
                VerkoopPrijs = 14500.00m,
                AanwezigInShowroom = true
            });

            voertuigen.Add(new Voertuig()
            {
                Merk = "Ford",
                MerkType = "Fiesta",
                Bouwjaar = 2016,
                Km = 60000,
                VerkoopPrijs = 9500.00m,
                AanwezigInShowroom = false
            });

            voertuigen.Add(new Voertuig()
            {
                Merk = "BMW",
                MerkType = "3 Series",
                Bouwjaar = 2019,
                Km = 25000,
                VerkoopPrijs = 32000.00m,
                AanwezigInShowroom = true
            });

            voertuigen.Add(new Voertuig()
            {
                Merk = "Audi",
                MerkType = "A4",
                Bouwjaar = 2021,
                Km = 10000,
                VerkoopPrijs = 38000.00m,
                AanwezigInShowroom = false
            });

            voertuigen.Add(new Voertuig()
            {
                Merk = "Mercedes-Benz",
                MerkType = "C-Class",
                Bouwjaar = 2017,
                Km = 35000,
                VerkoopPrijs = 27000.00m,
                AanwezigInShowroom = true
            });

            voertuigen.Add(new Voertuig()
            {
                Merk = "Honda",
                MerkType = "Civic",
                Bouwjaar = 2015,
                Km = 80000,
                VerkoopPrijs = 12000.00m,
                AanwezigInShowroom = false
            });

            voertuigen.Add(new Voertuig()
            {
                Merk = "Nissan",
                MerkType = "Qashqai",
                Bouwjaar = 2020,
                Km = 20000,
                VerkoopPrijs = 22000.00m,
                AanwezigInShowroom = true
            });

            voertuigen.Add(new Voertuig()
            {
                Merk = "Hyundai",
                MerkType = "Tucson",
                Bouwjaar = 2021,
                Km = 15000,
                VerkoopPrijs = 28000.00m,
                AanwezigInShowroom = true
            });

            voertuigen.Add(new Voertuig()
            {
                Merk = "Tesla",
                MerkType = "Model 3",
                Bouwjaar = 2022,
                Km = 5000,
                VerkoopPrijs = 45000.00m,
                AanwezigInShowroom = false
            });

            return voertuigen;
        }

        public static void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                
                if (!context.Voertuigen.Any())
                {
                    foreach (var voertuig in GetVoertuigen())
                    {
                        context.Voertuigen.Add(voertuig);
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
