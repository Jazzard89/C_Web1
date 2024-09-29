using Microsoft.EntityFrameworkCore;
using MVCClientLocEFCore.Models;

namespace MVCClientLocEFCore.Data
{
    #region DbContext
    public class ClientLocationContext: DbContext
    {
        public ClientLocationContext(DbContextOptions<ClientLocationContext> dbContext) : base(dbContext) 
        {
        
        }
        public DbSet<Location>? Location { get; set; }
        public DbSet<Client>? Client { get; set; }
        public DbSet<Product>? Product { get; set; }
    }
    #endregion

}
