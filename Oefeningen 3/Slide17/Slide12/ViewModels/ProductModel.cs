using Slide12.Models;

namespace Slide12.ViewModels
{
    public class ProductModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public IEnumerable<ResellerViewModel> Resellers { get; set; }
    }
}
