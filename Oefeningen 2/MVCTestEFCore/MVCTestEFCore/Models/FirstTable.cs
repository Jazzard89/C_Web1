using System.ComponentModel.DataAnnotations;

namespace MVCTestEFCore.Models
{
    public class FirstTable
    {
        public int FirstTableId { get; set; }
        [Required]
        public string TextColumn { get; set; }
    }
}
