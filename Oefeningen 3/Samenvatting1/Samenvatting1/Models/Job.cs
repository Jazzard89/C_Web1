using System.ComponentModel.DataAnnotations;

namespace Samenvatting1.Models
{
    public class Job
    {
        [Key]
        public int JobKey { get; set; }
        [Required]
        public string? JobName { get; set; }
        [Required]
        public string? JobDescription { get; set; }

        private decimal? _price;  
        public decimal Price => _price ?? 0;

        public Job()
        {

        }
        public Job(string[]data)
        {
            if (data.Length >= 2)
            {
                JobName = data[0];
                JobDescription = data[1];
            }
        }
    }
}
