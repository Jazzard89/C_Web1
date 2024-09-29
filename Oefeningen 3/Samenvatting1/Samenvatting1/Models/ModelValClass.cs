using Samenvatting1.CustomModelValidation;
using System.ComponentModel.DataAnnotations;

namespace Samenvatting1.Models
{
    public class ModelValClass
    {
        public int Number { get; set; }
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [CustomDate]
        public DateTime Date { get; set; }
    }
}
