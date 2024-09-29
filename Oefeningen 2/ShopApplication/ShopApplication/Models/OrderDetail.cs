namespace ShopApplication.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        //ProductId & OrderId are foreign Keys to the Order & Product Model (datatable)
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; } = null;
        public Product Product { get; set; } = null;
    }
}