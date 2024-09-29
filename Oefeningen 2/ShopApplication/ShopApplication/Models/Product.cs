using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApplication.Models
{
    public class Product
    {
        //Key sets the property bellow to the PrimairyKey, this is done automatically if 'Id' is in the back of it's name
        [Key]
        public int Id { get; set; }

        //Name is set to null because in .NET6 all projects enable nullable reference types by default.
        //If this isn't set, the project doesn't know where it's initialised, However EF Core does the initialisation for us
        //So we supress this warning by saying it's null. 
        public string Name { get; set; } = null;

        //If you need a nullable type in the model but you don't want it stored in the database, add Required
        [Required]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        //We add these 2 constructors
        public Product()
        {

        }
        public Product(string name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
