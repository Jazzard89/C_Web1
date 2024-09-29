using MVCSportStore.Models;

namespace MVCSportStore.ViewModels
{
    public class ResellerViewModel
    {
        public int ResellerId { get; set; }
        public string ResellerName { get; set; }
        public IEnumerable<ResellerStock> ResellerStocks { get; set; }
    }
}
