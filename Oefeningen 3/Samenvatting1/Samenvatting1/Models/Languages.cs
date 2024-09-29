using System.ComponentModel.DataAnnotations;

namespace Samenvatting1.Models
{
    public class Languages
    {
        [Key]
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string Framework { get; set; }
    }
}
