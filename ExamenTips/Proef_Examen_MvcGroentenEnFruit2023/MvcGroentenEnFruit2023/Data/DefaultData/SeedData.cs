using Microsoft.AspNetCore.Identity;
using MvcGroentenEnFruit2023.Models;

namespace MvcGroentenEnFruit2023.Data.DefaultData
{
    public class SeedData
    {

        public static async void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<GroentenEnFruitDbContext>();
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                await VoegRollenToeAsync(_context, _roleManager);
                await CreateIdentityRecordAsync(Roles.Aankoper, "aankoper@pxl.be", "Aankoper00!", Roles.Aankoper, _userManager);

                if (!_context.Orderlijns.Any())
                {
                    var artikel = new Artikel { ArtikelNaam = "Romatomaat", ArtikelId = 0 };
                    _context.Artikels.Add(artikel);
                    _context.SaveChanges();
                    IdentityUser user = await _userManager.FindByEmailAsync("aankoper@pxl.be");
                    var aankoopOrder = new AankoopOrder { AankoopDatum = "2023/12/21", IdentityUserId = user.Id, Status = 0 };
                    _context.AankoopOrders.Add(aankoopOrder);
                    _context.SaveChanges();

                    var orderlijn = new Orderlijn { ArtikelId = artikel.ArtikelId, Aantal = 5, AankoopOrderId = aankoopOrder.AankoopOrderId };
                    _context.Orderlijns.Add(orderlijn);
                    _context.SaveChanges();
                }
                
            }
        }

        private static async Task CreateIdentityRecordAsync(string userName, string email, string pwd, string role, UserManager<IdentityUser> _userManager)
        {

            if (_userManager != null && await _userManager.FindByEmailAsync(email) == null &&
                    await _userManager.FindByNameAsync(userName) == null)
            {
                var identityUser = new IdentityUser() { Email = email, UserName = userName };
                var result = await _userManager.CreateAsync(identityUser, pwd);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(identityUser, role);
                }
            }
        }

        private static async Task VoegRolToeAsync(RoleManager<IdentityRole> _roleManager, string roleName)
        {
            if(!await _roleManager.RoleExistsAsync(roleName))
            {
                IdentityRole role = new IdentityRole(roleName);
                await _roleManager.CreateAsync(role);
            }
        }
        private static async Task VoegRollenToeAsync(GroentenEnFruitDbContext _context, RoleManager<IdentityRole> _roleManager) 
        { 
            if (!_context.Roles.Any()) 
            { 
                await VoegRolToeAsync(_roleManager, Roles.Aankoper); 
                await VoegRolToeAsync(_roleManager, Roles.Gast); 
            } 
        }
    }
}
