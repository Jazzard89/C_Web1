using Microsoft.EntityFrameworkCore;
using Slide8.Models;

namespace Slide8.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Player>? Players { get; set; }
    }
}
