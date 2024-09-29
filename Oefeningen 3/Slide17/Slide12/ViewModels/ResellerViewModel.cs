using Slide12.Models;

namespace Slide12.ViewModels
{
    public class ResellerViewModel
    {
        public int ResellerId { get; set; }
        public string ResellerName { get; set; }
        public IEnumerable<ResellerStock> ResellerStocks { get; set; }
    }
}
