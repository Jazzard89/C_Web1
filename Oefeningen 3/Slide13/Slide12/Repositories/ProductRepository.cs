using Slide12.Data;
using Slide12.Models;
using Slide12.ViewModels;

namespace Slide12.Repositories
{
    public class ProductRepository
    {
        AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        private IEnumerable<Product> GetProducts(int productPage)
        {
            return _context.Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PagingSettings.ProductPagination)
                .Take(PagingSettings.ProductPagination);
        }

        private PagingInfo GetPagingInfo (int productPage)
        {
            var pagingInfo = new PagingInfo();
            pagingInfo.CurrentPage = productPage;
            pagingInfo.ItemsPerPage = PagingSettings.ProductPagination;
            pagingInfo.TotalItems = _context.Products.Count();
            return pagingInfo;
        }

        public ProductModel GetProductModel(int productPage)
        {
            var productModel = new ProductModel();
            productModel.Products = GetProducts(productPage);
            productModel.PagingInfo = GetPagingInfo(productPage);
            return productModel;
        }
    }
}
