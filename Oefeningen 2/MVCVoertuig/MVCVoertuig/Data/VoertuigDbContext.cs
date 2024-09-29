using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCVoertuig.Models;
using MVCVoertuig.ViewModels;

namespace MVCVoertuig.Data
{
    public class VoertuigDbContext: IdentityDbContext
    {
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options) : base(options) { }

        public DbSet<Voertuig>? Voertuigen { get; set; }

        public DbSet<MVCVoertuig.ViewModels.LoginViewModel>? LoginViewModel { get; set; }
    }
}
