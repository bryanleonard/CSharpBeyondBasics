using System;
using System.Globalization;
using Acme.Common;
using static Acme.Common.LoggingService;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory
    /// </summary>
    public class Product
    {
        #region Constants
        public const double InchesPerMeter = 39.37;
        public readonly decimal MiniumPrice;
        #endregion

        private TextInfo textInfo = new CultureInfo("en-us", false).TextInfo;
        //title = textInfo.ToTitleCase(title);

        #region Constructors
        public Product()
        {
            Console.WriteLine("Default constructor");
            this.ProductVendor = new Vendor();
            this.MiniumPrice = .96m;
            this.ProductCategory = "Tools";
        }

        public Product(int productId, string productName, string description) : this()
        {
            Console.WriteLine("Not the same code");
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;

            if (ProductName.StartsWith("Bulk"))
            {
                this.MiniumPrice = 9.96m;
            }
        }
        #endregion

        #region Properties
        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get
            {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Trim().Length < 3)
                {
                    ValidationMessage = "Product name must be at least 3 characters.";
                }
                else if (value.Trim().Length > 20)
                {
                    ValidationMessage = "Product name must be less than 20 characters.";
                }
                else
                {
                    productName = value.Trim();
                }
            }
        }

        public decimal ProductCost { get; set; }

        internal string ProductCategory { get; set; }

        public int SequenceNumber { get; set; } = 1;

        public string ProductCode => this.ProductCategory + "-" + this.SequenceNumber;

        public string ValidationMessage { get; private set; }

        public string Description { get; set; }

        private DateTime? AvailabilityDate { get; set; }

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

        private Vendor productVendor3;
        public Vendor ProductVendor3
        {
            get
            {
                if  (productVendor3 == null)
                {
                    productVendor3 = new Vendor();
                }
                return productVendor3;
            }
            set => productVendor3 = value;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Calculates suggested price.
        /// </summary>
        /// <param name="markupPercent"></param>
        /// <returns></returns>
        public decimal CalculateSuggestedPrice(decimal markupPercent) =>
            this.ProductCost + (this.ProductCost * markupPercent / 100);


        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("hi");

            var emailService = new EmailService();
            emailService.SendMessage("Subject", "Message: " + this.ProductName, "Recipient");

            //using static Acme.Common.LoggingService; allows us to call the method directly
            //var log = LoggingService.LogAction("Saying hello");
            var log = LogAction("Saying hello");


            return $"Hello ({ProductId}) {ProductName}: {Description}, Available on: {AvailabilityDate?.ToShortDateString()}";
        }




        #endregion



        #region Overrides

        public override string ToString()
        {
            return base.ToString();
            //return $"{this.ProductName} ({this.ProductId})";
        }
        #endregion
    }
}