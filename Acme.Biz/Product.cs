using System;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product
    {
        public Product()
        {
            Console.WriteLine("Product instance created");
        }

        public Product(int productId, string productName, string description) : this()
        {
            Console.WriteLine("Not the same code");
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }

        // ~ 6:15 min in on Defining Constructors

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        public string SayHello()
        {
            return $"Hello ({ProductId}) {ProductName}: {Description}";
        }
    }
}