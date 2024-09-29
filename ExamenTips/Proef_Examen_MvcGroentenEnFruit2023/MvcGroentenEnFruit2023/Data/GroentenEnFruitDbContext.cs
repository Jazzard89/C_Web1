using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit2023.Models;

namespace MvcGroentenEnFruit2023.Data
{
    public class GroentenEnFruitDbContext : IdentityDbContext
    {
        public GroentenEnFruitDbContext(DbContextOptions<GroentenEnFruitDbContext> options): base(options)
        {
            
        }

        public DbSet<Artikel> Artikels { get; set; }
        public DbSet<AankoopOrder> AankoopOrders { get; set;}
        public DbSet<Orderlijn> Orderlijns { get; set; }
        
    }
}
