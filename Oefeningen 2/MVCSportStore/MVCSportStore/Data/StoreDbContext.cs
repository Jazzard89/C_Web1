using Microsoft.EntityFrameworkCore;
using MVCSportStore.Models;

namespace MVCSportStore.Data
{
    public class StoreDbContext: DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Reseller>? Resellers { get; set; }
        public DbSet<ResellerStock>? ResellersStocks { get; set; }
    }
}
