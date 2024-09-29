using Slide12.Models;

namespace Slide12.Data.DefaultData
{
    public static class SeedData
    {
        private static IEnumerable<string> GetProductList()
        {
            List<string> products = new List<string>();

            products.Add("Kayak;A boat for one person;Watersports;275");
            products.Add("Lifejacket;Protective and fashionable;Watersports;48,95");
            products.Add("Soccer Ball;FIFA-approved size and weight;Soccer;19,5");
            products.Add("Corner Flags;Give your playing field a professional touch;Soccer;34,95");
            products.Add("Stadium;Flat-packed 35,000-seat stadium;Soccer;79500");
            products.Add("Thinking Cap;Improve brain efficiency by 75%;Chess;16");
            products.Add("Unsteady Chair;Secretly give your opponent a disadvantage;Chess;29,95");
            products.Add("Human Chess Board;A fun game for the family;Chess;75");
            products.Add("Bling-Bling King;Gold-plated, diamond-studded King;Chess;1200");

            return products;
        }
        private static IEnumerable<string> Products => GetProductList();

        public static void EnsurePopulated(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                if (!context.Products.Any())
                {
                    foreach (var productString in Products)
                    {
                        var product = new Product(productString.Split(';'));
                        context.Products.Add(product);
                    }
                    context.SaveChanges();
                }
                MatchResellerData(context);
            }
        }
        public static void MatchResellerData(AppDbContext context)
        {
            var resellers = context.Resellers;
            bool entityAdded = false;
            foreach(var reseller in resellers)
            {
                if (!context.Resellers.Where(x => x.ContentManagementGuid == reseller.ContentManagementGuid).Any())
                {
                    var newReseller = new Reseller();
                    newReseller.ResellerName = reseller.ResellerName;
                    newReseller.ContentManagementGuid = reseller.ContentManagementGuid;
                    context.Resellers.Add(newReseller);
                    entityAdded = true;
                }
            }
        }

        public static void MatchResellerStockData(AppDbContext context)
        {
            var resellerStocks = context.ResellerStocks;
            bool entityAdded = false;
            foreach (var resellerStock in resellerStocks)
            {
                if (!context.ResellerStocks.Any(rs => rs.ResellerId == resellerStock.ResellerId && rs.ProductId == resellerStock.ProductId))
                {
                    var newResellerStock = new ResellerStock
                    {
                        ResellerId = resellerStock.ResellerId,
                        ProductId = resellerStock.ProductId,
                        Amount = resellerStock.Amount
                    };

                    context.ResellerStocks.Add(newResellerStock);
                    entityAdded = true;
                }
            }
            if (entityAdded)
            {
                context.SaveChanges();
            }
        }
    }
}
