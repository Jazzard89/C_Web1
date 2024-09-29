namespace ShopApplication.Models
{
    public class Customer
    {
        public int Id { get; set; }
        //FirstName & LastName are non-nullable, so these 2 columns are allowed to have null but not in the database
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        //Address & Phone are nullable, so the database will allow null in these columns
        //We don't need to initialise these
        public string? Address { get; set; }
        public string? Phone { get; set; }

        //This is a navigation property, it may indicate that a customer can have zero or more orders (1 to many)
        public ICollection<Order> Orders { get; set; } = null;
    }
}
