using Microsoft.EntityFrameworkCore;
using Slide18.Models;

namespace Slide18.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Voertuig>? Voertuigen { get; set; }
    }
}
