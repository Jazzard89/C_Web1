using Microsoft.EntityFrameworkCore;
using MVCTagHelper.Models;

namespace MVCTagHelper.Data
{
    public class TagHelperDbContext: DbContext
    {
        public TagHelperDbContext(DbContextOptions<TagHelperDbContext> options) : base(options) { }

        public DbSet<Locatie> Locatie { get; set; }
        public DbSet<Land> Land { get; set; }
        public DbSet<Afdeling> Afdeling { get; set; }
        public DbSet<Medewerker> Medewerker { get; set; }
    }
}
