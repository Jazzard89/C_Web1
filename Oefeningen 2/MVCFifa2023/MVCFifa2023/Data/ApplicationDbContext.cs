using Microsoft.EntityFrameworkCore;
using MVCFifa2023.Models;

namespace MVCFifa2023.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        
        }
        public DbSet<Player>? Players { get; set; }
        public DbSet<Team>? Teams { get; set; }
        public DbSet<TeamPlayer>? TeamPlayers { get; set; }
        public DbSet<NewPlayer>? NewPlayers { get; set; }
    }
}
