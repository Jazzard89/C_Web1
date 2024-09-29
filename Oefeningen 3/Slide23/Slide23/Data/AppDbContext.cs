using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slide23.Models;

namespace Slide23.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Artikel>? Artikels { get; set; }
        public DbSet<AankoopOrder>? AankoopOrders { get; set;}
        public DbSet<VerkoopOrder>? VerkoopOrders { get; set;}
    }
}
