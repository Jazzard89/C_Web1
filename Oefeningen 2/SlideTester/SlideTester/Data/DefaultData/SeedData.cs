using SlideTester.Models;

namespace SlideTester.Data.DefaultData
{
    public static class SeedData
    {
        private static IEnumerable<string> Products = GetproductList();

        private static IEnumerable<string> GetproductList()
        {
            List<string> products = new List<string>();

            products.Add("Lifejacket; Protective and fashionalbe;48");
            products.Add("Gun; For the hunting; 20");

            return products;
        }


        public static void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TesterDbContext>();
                if (!context.Products.Any())
                {
                    foreach (var productText in Products)
                    {
                        var arr = productText.Split(";");

                        if (arr.Length > 0)
                        {
                            var product = new Product(arr[0], arr[1], decimal.Parse(arr[2]));

                            // Add the newly created product to the context
                            context.Products.Add(product);
                        }
                    }

                    // Save changes to the database
                    context.SaveChanges();
                }
            }
        }

    }
}
