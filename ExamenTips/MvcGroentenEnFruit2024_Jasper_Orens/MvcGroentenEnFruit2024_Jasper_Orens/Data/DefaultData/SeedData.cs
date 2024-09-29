using Microsoft.AspNetCore.Identity;
using MvcGroentenEnFruit2024_Jasper_Orens.Models;

namespace MvcGroentenEnFruit2024_Jasper_Orens.Data.DefaultData
{
    public static class SeedData
    {

        public static IEnumerable<Artikel> Artikels => GetArtikelsList();

        public static async void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var _userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                await VoegRollenToeAsync(_context, _roleManager);
                await CreateIdentityRecordAsync(Roles.Aankoper, "aankoper@pxl.be", "Aankoper00!",
                    Roles.Aankoper, _userManager);

                if (!_context.Artikels.Any())
                {
                    _context.Artikels.AddRange(Artikels);
                    _context.SaveChanges();
                }
                if(!_context.AankoopOrders.Any())
                {
                    _context.AankoopOrders.AddRange(GetAankoopOrdersList(_userManager));
                    _context.SaveChanges();
                }
                if(!_context.OrderLijnen.Any())
                {
                    _context.OrderLijnen.AddRange(GetOrderLijnList(_context));
                    _context.SaveChanges();
                }
            }
        }
        #region Roles
        private static async Task VoegRollenToeAsync(AppDbContext context, RoleManager<IdentityRole> roleManager)
        {
            if(!context.Roles.Any())
            {
                await VoegRolToeAsync(roleManager, Roles.Aankoper);
                await VoegRolToeAsync(roleManager, Roles.Gast);
                await VoegRolToeAsync(roleManager, Roles.Verkoper);
            }
        }
        private static async Task VoegRolToeAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }
        #endregion

        #region Identity
        private static async Task CreateIdentityRecordAsync(string userName, string email, string password, string role, UserManager<IdentityUser> userManager)
        {
            if (userManager != null && await userManager.FindByNameAsync(userName) == null && await userManager.FindByNameAsync(userName) == null)
            {
                IdentityUser user = new IdentityUser(userName);
                user.Email = email;
                user.EmailConfirmed = true;
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
        #endregion

        public static IEnumerable<Artikel> GetArtikelsList()
        {
            List<Artikel> artikels = new List<Artikel>();
            artikels.Add(new Artikel { ArtikelNaam = "Roma tomaat" });

            return artikels;
        }

        public static IEnumerable<AankoopOrder> GetAankoopOrdersList(UserManager<IdentityUser> _userManager)
        {
            List<AankoopOrder> aankoopOrders = new List<AankoopOrder>();
            aankoopOrders.Add(new AankoopOrder { AankoopDatum = Convert.ToDateTime("2023/12/21"), 
                IdentityUserId =  _userManager.FindByEmailAsync("aankoper@pxl.be").Result.Id, Status=0});

            return aankoopOrders;
        }

        public static IEnumerable<OrderLijn> GetOrderLijnList(AppDbContext _context)
        {
            List<OrderLijn> orderlijnen = new List<OrderLijn>();
            orderlijnen.Add(new OrderLijn 
            {
                AankoopOrderId = _context.AankoopOrders.Where(x => x.AankoopOrderId == 1).Select(x => x.AankoopOrderId).FirstOrDefault(), 
                ArtikelId = _context.Artikels.Where(x => x.ArtikelNaam == "Roma tomaat").Select(x => x.ArtikelId).FirstOrDefault(),
                Aantal = 5 
            });

            return orderlijnen;
        }

    }
}
