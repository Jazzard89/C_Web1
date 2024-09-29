using Microsoft.AspNetCore.Identity;
using ProefExamen2.Models;

namespace ProefExamen2.Data.DefaultData
{
    public class SeedData
    {
        public async static void EnsureCreatedAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                await CreateRoles(roleManager);
                await CreateUsers(userManager);
                AddBoeken(dbContext);
                await AddBestellingsRegels(dbContext, userManager);
            }
        }
        

        public async static Task CreateRoles(RoleManager<IdentityRole> _roleManager)
        {
            if (!await _roleManager.RoleExistsAsync(Roles.Beheerder))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Beheerder));
            }

            if (!await _roleManager.RoleExistsAsync(Roles.Klant))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Klant));
            }

            if (!await _roleManager.RoleExistsAsync(Roles.Administator))
            {
                await _roleManager.CreateAsync(new IdentityRole(Roles.Administator));
            }
        }

        public async static Task CreateUsers(UserManager<IdentityUser> _userManager)
        {
            var user = await _userManager.FindByNameAsync("beheerder@standaard.be");
            if (user == null)
            {
                user = new IdentityUser
                {
                    UserName = "beheerder",
                    Email = "beheerder@standaard.be"
                };
                await _userManager.CreateAsync(user, "P@ssword1");
                await _userManager.AddToRoleAsync(user, Roles.Beheerder);
            }
            var admin = await _userManager.FindByNameAsync("admin@standaard.be");
            if (admin == null)
            {
                admin = new IdentityUser
                {
                    UserName = "administrator",
                    Email = "admin@standaard.be"
                };
                await _userManager.CreateAsync(admin, "P@ssword1");
                await _userManager.AddToRoleAsync(admin, Roles.Administator);
            }
        }

        public static void AddBoeken(AppDbContext _Context)
        {
            if (!_Context.Boeken.Any())
            {
                _Context.Boeken.AddRange(
                    new Boek { Titel = "Lord of the rings, the Fellowship of the ring, The", Auteur = "J.R.R. Tolkien", Prijs = 20.00M, Afbeelding = "boek1.jpg" },
                    new Boek { Titel = "Stars in your Eyes", Auteur = "Kacen Callender", Prijs = 15.00M, Afbeelding = "boek2.jpg" }
                );
                _Context.SaveChanges();
            }
        }

        public static async Task AddBestellingsRegels(AppDbContext _Context, UserManager<IdentityUser> _UserManger)
        {
            if (!_Context.BestellingsRegels.Any())
            {
                if (!_Context.Bestellingen.Any())
                {
                    var bestelling = new Bestelling
                    {
                        BestelDatum = DateTime.Parse("08/16/2024"),
                        IdentityUserId = (await _UserManger.FindByEmailAsync("beheerder@standaard.be")).Id,
                        Status = 1
                    };
                    _Context.Bestellingen.Add(bestelling);
                    await _Context.SaveChangesAsync();
                }

                var boekId = _Context.Boeken
                    .Where(x => x.Titel == "Stars in your Eyes")
                    .Select(x => x.BoekId)
                    .FirstOrDefault();

                _Context.BestellingsRegels.Add(new BestellingsRegel
                {
                    BestellingId = _Context.Bestellingen.FirstOrDefault().BestellingId,
                    BoekId = boekId,
                    Aantal = 2
                });
                await _Context.SaveChangesAsync();
            }
        }
    }
}
