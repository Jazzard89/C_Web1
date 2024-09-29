namespace ShopApplication.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime? OrderFulfilled { get; set; }
        //We included the customerId property to generate the foreignKey between the Customer table
        public int CustomerId { get; set; }
        //Navigation property, specifies one customer per order
        public Customer Customer { get; set; } = null;
        public ICollection<OrderDetail> OrderDetails { get; set; } = null;
    }
}
