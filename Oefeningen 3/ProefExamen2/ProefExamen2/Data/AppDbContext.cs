using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProefExamen2.Models;

namespace ProefExamen2.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Boek>? Boeken { get; set; }
        public DbSet<Bestelling>? Bestellingen { get; set; }
        public DbSet<BestellingsRegel>? BestellingsRegels { get; set; }
    }
}
