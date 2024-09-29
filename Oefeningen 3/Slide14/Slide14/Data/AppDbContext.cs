using Microsoft.EntityFrameworkCore;
using Slide14.Models;

namespace Slide14.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Afdeling> afdelingen { get; set; }
        public DbSet<Land> landen { get; set; }
        public DbSet<Locatie> locaties { get; set; }
    }
}
