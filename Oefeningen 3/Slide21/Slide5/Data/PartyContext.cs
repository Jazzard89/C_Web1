using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slide5.Models;
using Slide5.ViewModels;

namespace Slide5.Data
{
    public class PartyContext : IdentityDbContext
    {
        public PartyContext(DbContextOptions<PartyContext> options) : base(options) { }
        public DbSet<Gast>? Gasten { get; set; }
        public DbSet<Slide5.ViewModels.LoginViewModel>? LoginViewModel { get; set; }
        public DbSet<Slide5.ViewModels.RegisterViewModel>? RegisterViewModel { get; set; }
    }
}
