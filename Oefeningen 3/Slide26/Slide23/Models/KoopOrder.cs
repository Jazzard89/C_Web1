using Microsoft.AspNetCore.Identity;

namespace Slide23.Models
{
    public class KoopOrder
    {
        public int ArtikelId { get; set; }
        public int Hoeveelheid { get; set; }
        public Artikel? Artikel { get; set; }

        public string? IdentityUserId { get; set; }
        public IdentityUser? IdentityUser { get; set; }
    }
}
