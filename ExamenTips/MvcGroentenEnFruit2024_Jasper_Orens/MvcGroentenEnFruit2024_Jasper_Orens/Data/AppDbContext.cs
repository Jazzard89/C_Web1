using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit2024_Jasper_Orens.Models;

namespace MvcGroentenEnFruit2024_Jasper_Orens.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Artikel>? Artikels { get; set; }
        public DbSet<AankoopOrder>? AankoopOrders { get; set; }
        public DbSet<OrderLijn>? OrderLijnen { get; set; }
    }
}
