using Microsoft.EntityFrameworkCore;
using SlideTester.Models;

namespace SlideTester.Data
{
    public class TesterDbContext : DbContext
    {
        public TesterDbContext(DbContextOptions<TesterDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
