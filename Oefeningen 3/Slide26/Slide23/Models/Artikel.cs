using System.ComponentModel.DataAnnotations;

namespace Slide23.Models
{
    public class Artikel
    {
        public Artikel(string? naam)
        {
            Naam = naam;
        }
        [Key]
        public int ArtikelId { get; set; }
        public string? Naam { get; set; }
        public ICollection<AankoopOrder>? AankoopOrders { get; set; }
        public ICollection<VerkoopOrder>? VerkoopOrders { get; set; }
    }
}
