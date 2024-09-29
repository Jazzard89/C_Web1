using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit2024_2.Models;
using MvcGroentenEnFruit2024_2.Models.ViewModels;


namespace MvcGroentenEnFruit2024_2.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AankoopOrder> AankoopOrders { get; set; }
        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<OrderLijn> OrderLijnen { get; set; }
    }
}
