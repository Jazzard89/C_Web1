using System.ComponentModel.DataAnnotations;

namespace MVCSportStore.Models
{
    public class Reseller
    {
        public int ResellerId { get; set; }
        public string? ResellerName { get; set; }
        public string? ContentManagementGuid { get; set; }

        public ICollection<ResellerStock>? ResellerStocks { get; set; }
    }
}
