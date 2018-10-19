using System;
using System.Text;
using Acme.Common;

namespace Acme.Biz
{
    /// <summary>
    ///     Manages the vendors we purchase inventory from
    /// </summary>
    public class Vendor
    {

        #region Properties
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        #endregion

        #region Methods
        /// <summary>
        ///     Sends an email to welcome new vendor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ($"Hello {this.CompanyName}").Trim();
            var confirmation = emailService.SendMessage(subject, message, this.Email);

            return confirmation;
        }


        /// <summary>
        /// BOOOOYYYYYYYEEEEEE! Sends a product to the vendor.
        /// </summary>
        /// <param name="product">Product to order.</param>
        /// <param name="quantity">Quantity of the product to order.</param>
        /// <returns></returns>
        public bool PlaceOrder(Product product, int quantity)
        {
            //guard clauses
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0)   throw new ArgumentOutOfRangeException(nameof(quantity));

            var success = false;

            var orderText = $"Order of {quantity} of {product.ProductCode}.";
            
            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }

            return success;
        }


        // return more than just true or false
        public OperationResult PlaceOrder2(Product product, int quantity)
        {
            //guard clauses
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            var success = false;

            var orderText = $"Order of {quantity} of {product.ProductCode}.";

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }

            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// BOOOOYYYYYYYEEEEEE! Sends a product to the vendor.
        /// </summary>
        /// <param name="product">Product to order.</param>
        /// <param name="quantity">Quantity of the product to order.</param>
        /// <param name="deliveryBy">Requested delivery date.</param>
        /// <returns></returns>
        public OperationResult PlaceOrder2(Product product, int quantity, DateTimeOffset? deliveryBy)
        {
            //guard clauses
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliveryBy <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(deliveryBy));

            var success = false;

            var orderText = $"Order of {quantity} of {product.ProductCode}.";

            if (deliveryBy.HasValue)
            {
                orderText += $" Deliver by: {deliveryBy.Value:d}";
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }

            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }



        public OperationResult PlaceOrder2(Product product, int quantity, DateTimeOffset? deliverBy, string instructions)
        {
            //guard clauses
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;

            var orderText = $"Order of {quantity} of {product.ProductCode}.";

            if (deliverBy.HasValue)
            {
                orderText += $" Deliver by: {deliverBy.Value:d}";
            }

            if (!String.IsNullOrWhiteSpace(instructions))
            {
                orderText += $" Instructions: {instructions}.";
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }

            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }








        //Method Chaining, where a method overload calls another method overload 
        public OperationResult PlaceOrderChain(Product product, int quantity)
        {
            return PlaceOrderChain(product, quantity, null, null);
        }

        public OperationResult PlaceOrderChain(Product product, int quantity,
            DateTimeOffset? deliverBy)
        {
            return PlaceOrderChain(product, quantity, deliverBy, null);
        }

        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <param name="deliverBy"></param>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public OperationResult PlaceOrderChain(Product product, int quantity,
            DateTimeOffset? deliverBy, string instructions)
        {
            //guard clauses
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
            if (deliverBy <= DateTimeOffset.Now) throw new ArgumentOutOfRangeException(nameof(deliverBy));

            var success = false;
            var orderText = $"Order of {quantity} of {product.ProductCode}.";

            if (deliverBy.HasValue)
            {
                orderText += $" Deliver by: {deliverBy.Value:d}";
            }

            if (!String.IsNullOrWhiteSpace(instructions))
            {
                orderText += $" Instructions: {instructions}.";
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);

            if (confirmation.StartsWith("Message sent:"))
            {
                success = true;
            }

            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }


        /// <summary>
        /// Sends a product order to the vendor
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <param name="includeAddress"></param>
        /// <param name="sendCopy"></param>
        /// <returns></returns>
        public OperationResult PlaceOrder_ParamAdjustment(Product product, int quantity, 
                                                            bool includeAddress, bool sendCopy)
        {
            var orderText = "Test";
            if (includeAddress) orderText += " with address";
            if (sendCopy) orderText += " with copy";

            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }

        #endregion



        #region Enumerated Parameter Option

        // These are normally at the top of the class
        public enum IncludeAddress { Yes, No };
        public enum SendCopy { Yes, No };

        public OperationResult PlaceOrder_ParamEnumAdjustment(Product product, int quantity,
            IncludeAddress includeAddress, SendCopy sendCopy)
        {
            var orderText = "Test";
            if (includeAddress == IncludeAddress.Yes) orderText += " with address";
            if (sendCopy == SendCopy.Yes) orderText += " with copy";

            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }



        public OperationResult PlaceOrder_OptionalParams(Product product, int quantity,
            IncludeAddress? includeAddress = null, string instructions = "standard delivery")
        {
            //guard clauses
            if (product == null) throw new ArgumentNullException(nameof(product));
            if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));

            var success = false;
            var orderText = $"Test";

            if (includeAddress == IncludeAddress.Yes)
            {
                orderText += $" with address";
            }

            if (!String.IsNullOrWhiteSpace(instructions))
            {
                orderText += $" with instructions";
            }

            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }
        #endregion
    }
}