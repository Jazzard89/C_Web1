using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Slide23.Models;


namespace Slide23.Data.DefaultData
{
    public static class SeedData
    {
        public static IEnumerable<Artikel> Artikels => GetArtikelList();
        public static IEnumerable<Artikel> GetArtikelList()
        {
            List<Artikel> artikels = new List<Artikel>();
            artikels.Add(new Artikel("Peterselie"));
            artikels.Add(new Artikel("Peer"));
            artikels.Add(new Artikel("Tomaat"));
            artikels.Add(new Artikel("Wortel"));
            artikels.Add(new Artikel("Pattat"));
            return artikels;
        }
        public static async Task EnsurePopulatedAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await VoegRollenToeAsync(_context, _roleManager);

                if (!_context.Artikels.Any())
                {
                    foreach (Artikel artikel in Artikels)
                    {
                        _context.Artikels.Add(artikel);
                    }
                    await _context.SaveChangesAsync();
                }
            }
        }


        private static async Task VoegRolToeAsync(RoleManager<IdentityRole> _roleManager, string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }
        }
        private static async Task VoegRollenToeAsync(AppDbContext _context, RoleManager<IdentityRole> _roleManager)
        {
            if (!_context.Roles.Any())
            {
                await VoegRolToeAsync(_roleManager, Roles.Aankoper);
                await VoegRolToeAsync(_roleManager, Roles.Verkoper);
            }
        }
    }
}
