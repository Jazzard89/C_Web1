using System.ComponentModel.DataAnnotations;

namespace Slide5.Models
{
    public class TestData
    {
        [Key]
        public int TestDataId { get; set; }
        [Required]
        [StringLength(50)]
        public string Tekst { get; set; }
        [Required]
        //[CustomDate]
        public DateTime? Datum { get; set; }
    }
}
