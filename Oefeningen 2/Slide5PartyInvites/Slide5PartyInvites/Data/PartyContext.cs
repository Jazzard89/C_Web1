using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Slide5PartyInvites.Models;
using Slide5PartyInvites.ViewModels;

namespace Slide5PartyInvites.Data
{
    public class PartyContext : IdentityDbContext
    {
        public PartyContext(DbContextOptions<PartyContext> options) : base(options) { }
        public DbSet<Gast>? Gasten { get; set; }
        public DbSet<Slide5PartyInvites.ViewModels.LoginViewModel>? LoginViewModel { get; set; }
        public DbSet<Slide5PartyInvites.ViewModels.RegisterViewModel>? RegisterViewModel { get; set; }
    }
}
