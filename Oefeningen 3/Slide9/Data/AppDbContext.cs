using Microsoft.EntityFrameworkCore;
using Slide9.Models;

namespace Slide9.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Slide9.Models.Location>? Location { get; set; }
    }
}
