using Microsoft.AspNetCore.Identity;
using MvcGroentenEnFruit2024_2.Models;


namespace MvcGroentenEnFruit2024_2.Data.DefaultData
{
    public class SeedData
    {
        public static async void EnsurePopulatedAsync(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                await VoegRollenToeAsync(_context, _roleManager);
                await CreateIdentityRecordAsync("Aankoper", "aankoper@pxl.be", "Aankoper00!", Roles.Aankoper, _userManager);

                if (!_context.Artikels.Any())
                {
                    var artikel = new Artikel { ArtikelNaam = "Roma tomaat" };
                    _context.Artikels.Add(artikel);
                    _context.SaveChanges();
                }
                var user = await _userManager.FindByEmailAsync("aankoper@pxl.be");
                if (!_context.AankoopOrders.Any())
                {
                    var aankoopOrders = new AankoopOrder()
                    { 
                        AankoopDatum = Convert.ToDateTime("2023/12/21"),
                        IdentityUserId = user.Id,
                        Status = 0
                    };
                    _context.AankoopOrders.Add(aankoopOrders);
                    _context.SaveChanges();
                }
                if (!_context.OrderLijnen.Any())
                {

                   var orderLijn = new OrderLijn()
                    {
                        ArtikelId = 1,
                        Aantal = 5
                    };
                    _context.OrderLijnen.Add(orderLijn);
                    _context.SaveChanges();
                }
                
            }
        }

        private static async Task VoegRolToeAsync(RoleManager<IdentityRole> roleManager, string rol)
        {
            if(!await roleManager.RoleExistsAsync(rol))
            {
                await roleManager.CreateAsync(new IdentityRole(rol));
            }
        }
    
        private static async Task VoegRollenToeAsync(AppDbContext _context, RoleManager<IdentityRole> roleManager)
        {
            if (!_context.Roles.Any())
            {
                await VoegRolToeAsync(roleManager, Roles.Gast);
                await VoegRolToeAsync(roleManager, Roles.Aankoper);
            }
        }

        private static async Task CreateIdentityRecordAsync(string userName, string email, string pwd, string role, UserManager<IdentityUser> _userManager)
        {
            if (_userManager != null && await _userManager.FindByEmailAsync(email) == null &&
                await _userManager.FindByNameAsync(userName) == null)
            {
                var identityUser = new IdentityUser()
                {
                    Email = email,
                    UserName = userName
                };
                var result = await _userManager.CreateAsync(identityUser, pwd);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, role);
                }
            }
        }
    
    
    
    }
}
