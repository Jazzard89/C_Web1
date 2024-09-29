namespace Slide12.Models
{
    public class Reseller
    {
        public int ResellerId { get; set; }
        public string ResellerName { get; set; }
        public string ContentManagementGuid { get; set; }

        public IEnumerable<ResellerStock>? Stocks { get; set; }
    }
}
