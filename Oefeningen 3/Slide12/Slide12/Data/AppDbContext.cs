using Microsoft.EntityFrameworkCore;
using Slide12.Models;

namespace Slide12.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}
