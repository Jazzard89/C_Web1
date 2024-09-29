using Microsoft.EntityFrameworkCore;
using Samenvatting1.Models;
using System.Security.Cryptography.X509Certificates;

namespace Samenvatting1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Languages> Languages { get; set; }
    }
}
