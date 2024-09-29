using MVCVoertuig.Models;

namespace MVCVoertuig.Data.DefaultData
{
    public static class SeedData
    {
        public static void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<VoertuigDbContext>();
                if (!context.Voertuigen.Any())
                {
                    foreach(var voertuig in GetVoertuigen())
                    {
                        context.Voertuigen.Add(voertuig);
                    }
                    context.SaveChanges();
                }
            }
        }

        private static IEnumerable<Voertuig> Voertuigen => GetVoertuigen();
        private static IEnumerable<Voertuig> GetVoertuigen()
        {
            List<Voertuig> voertuigen = new List<Voertuig>();

            voertuigen.Add(new Voertuig { Merk="Ford", MerkType="Mondeo", Bouwjaar=2010, AanwezigInShowroom=true, Km=20000, VerkoopPrijs=3000});
            voertuigen.Add(new Voertuig { Merk = "Toyota", MerkType = "Camry", Bouwjaar = 2015, AanwezigInShowroom = true, Km = 35000, VerkoopPrijs = 8000 });
            voertuigen.Add(new Voertuig { Merk = "Honda", MerkType = "Accord", Bouwjaar = 2018, AanwezigInShowroom = false, Km = 25000, VerkoopPrijs = 12000 });
            voertuigen.Add(new Voertuig { Merk = "Chevrolet", MerkType = "Cruze", Bouwjaar = 2016, AanwezigInShowroom = true, Km = 28000, VerkoopPrijs = 7500 });
            voertuigen.Add(new Voertuig { Merk = "Nissan", MerkType = "Altima", Bouwjaar = 2017, AanwezigInShowroom = true, Km = 32000, VerkoopPrijs = 9000 });
            voertuigen.Add(new Voertuig { Merk = "Volkswagen", MerkType = "Passat", Bouwjaar = 2019, AanwezigInShowroom = false, Km = 18000, VerkoopPrijs = 15000 });
            voertuigen.Add(new Voertuig { Merk = "Hyundai", MerkType = "Sonata", Bouwjaar = 2014, AanwezigInShowroom = true, Km = 40000, VerkoopPrijs = 7000 });
            voertuigen.Add(new Voertuig { Merk = "BMW", MerkType = "3 Series", Bouwjaar = 2020, AanwezigInShowroom = true, Km = 15000, VerkoopPrijs = 25000 });
            voertuigen.Add(new Voertuig { Merk = "Mercedes-Benz", MerkType = "C-Class", Bouwjaar = 2015, AanwezigInShowroom = false, Km = 27000, VerkoopPrijs = 18000 });
            voertuigen.Add(new Voertuig { Merk = "Audi", MerkType = "A4", Bouwjaar = 2017, AanwezigInShowroom = true, Km = 22000, VerkoopPrijs = 20000 });
            voertuigen.Add(new Voertuig { Merk = "Lexus", MerkType = "ES", Bouwjaar = 2016, AanwezigInShowroom = false, Km = 30000, VerkoopPrijs = 17000 });
            voertuigen.Add(new Voertuig { Merk = "Ford", MerkType = "Focus", Bouwjaar = 2018, AanwezigInShowroom = true, Km = 19000, VerkoopPrijs = 11000 });
            voertuigen.Add(new Voertuig { Merk = "Toyota", MerkType = "Corolla", Bouwjaar = 2019, AanwezigInShowroom = false, Km = 25000, VerkoopPrijs = 12000 });
            voertuigen.Add(new Voertuig { Merk = "Honda", MerkType = "Civic", Bouwjaar = 2017, AanwezigInShowroom = true, Km = 28000, VerkoopPrijs = 9000 });
            voertuigen.Add(new Voertuig { Merk = "Chevrolet", MerkType = "Malibu", Bouwjaar = 2016, AanwezigInShowroom = true, Km = 30000, VerkoopPrijs = 10000 });


            return voertuigen;
        }
    }
}
