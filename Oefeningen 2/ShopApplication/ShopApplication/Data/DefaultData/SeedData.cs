using ShopApplication.Models;

namespace ShopApplication.Data.DefaultData
{
    public static class SeedData
    {
        //We create an IEnumerable that is a collection of strings, these strings are Products with their needed parameters 
        //as you can see in Product.cs inside this model we need a Name, a description and a price, all of this is inside the string
        private static IEnumerable<string> Products => GetproductList();

        //We create a method that gets all products from our seed data here
        //since it's a IEnumerable<string> method we must return just that
        private static IEnumerable<string> GetproductList()
        {
            List<string> products = new List<string>();

            products.Add("Lifejacket;Protective and fashionable;48");
            products.Add("Flaregun;For alerting others in the wild;251");

            return products;
        }

        //This void method ensures that the database is filled when the application is started
        public static void EnsurePopulated(WebApplication app)
        {
            //we use createScope because we want this to be added to the app temporarly, the 'using' will ensure it's closed when this 
            //function is completed
            using (var scope = app.Services.CreateScope())
            {
                //We summon from the service we created in program.cs
                var context = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
                //If the context does not contain products we will excecute the following
                if (!context.Products.Any())
                {
                    //Inside 'GetproductList' we added strings that are devided with a ';' here we split it up into items
                    foreach (var productText in Products)
                    {
                        var arr = productText.Split(';');

                        if (arr.Length > 0)
                        {
                            var product = new Product(arr[0], arr[1], decimal.Parse(arr[2])); //We get an error here because Product doesn't take an argument. We will handle this 
                            context.Products.Add(product);
                        }
                    }

                    //Always save your changes !!!!
                    context.SaveChanges();
                }
            }
        }
    }
}
