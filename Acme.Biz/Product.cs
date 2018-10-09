using System;
using Acme.Common;
using static Acme.Common.LoggingService;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            Console.WriteLine("Default constructor");
            this.ProductVendor = new Vendor();
        }

        public Product(int productId, string productName, string description) : this()
        {
            Console.WriteLine("Not the same code");
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }

        //private Vendor productVendor;

        //public Vendor ProductVendor
        //{
        //    get => productVendor;
        //    set => productVendor = value;
        //}
        public Vendor ProductVendor { get; set; }


        private Vendor productVendor2;
        public Vendor ProductVendor2
        {
            get => productVendor2 ?? (productVendor2 = new Vendor());
            set => productVendor2 = value;
        }
        #endregion

        #region Methods
        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("hi");

            var emailService = new EmailService();
            emailService.SendMessage("Subject", "Message: " + this.ProductName, "Recipient");

            //using static Acme.Common.LoggingService; allows us to call the method directly
            //var log = LoggingService.LogAction("Saying hello");
            var log = LogAction("Saying hello");


            return $"Hello ({ProductId}) {ProductName}: {Description}";
        }
        #endregion
    }
}