using System.ComponentModel.DataAnnotations;

namespace Samenvatting1.Models
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }

        public Location()
        {

        }
        public Location(string data)
        {
            string[] allData = data.Split(';');
            City = allData[0];
            PostalCode = allData[1];
        }
        public Location(string[] data)
        {
            //this is used in SeedData
            City = data[0];
            PostalCode = data[1];
        }
    }
}
