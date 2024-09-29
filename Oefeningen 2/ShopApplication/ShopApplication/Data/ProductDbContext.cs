using Microsoft.EntityFrameworkCore;
using ShopApplication.Models;

namespace ShopApplication.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        //Placing the exclamation mark at the end means that we know the database will be empty but it's intended
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    }
}
