using System;
using Xunit;
using Acme.Biz;
using Acme.Common;

namespace Acme.BizTests
{
    public class VendorTests
    {
        [Fact]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            //var vendor = new Vendor();
            //vendor.CompanyName = "ABC Corp";
            var vendor = new Vendor
            {
                CompanyName = "ABC Corp"
            };
            var expected = "Message sent: Hello ABC Corp";
            var actual = vendor.SendWelcomeEmail("Test Message");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            var vendor = new Vendor()
            {
                CompanyName = ""
            };

            var expected = "Message sent: Hello";
            var actual = vendor.SendWelcomeEmail("Test Message");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            var vendor = new Vendor()
            {
                CompanyName = null
            };

            var expected = "Message sent: Hello";
            var actual = vendor.SendWelcomeEmail("Test Message");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void PlaceOrder_Default()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = true;

            //Act
            var actual = vendor.PlaceOrder(product, 12);

            //Assert
            Assert.Equal(expected, actual);
        }




        [Fact]
        public void PlaceOrder_NullProductException()
        {
            //Arrange
            var vendor = new Vendor();

            //Act
            //Action act = () => vendor.PlaceOrder(null, 12);
            void Act() => vendor.PlaceOrder(null, 12);

            //Assert
            //Exception ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Throws<ArgumentNullException>((Action) Act);
        }


        [Fact]
        public void PlaceOrder_NullQuantityException()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");

            //Act
            //Action act = () => vendor.PlaceOrder(null, 12);
            void Act() => vendor.PlaceOrder(product, 0);

            //Assert
            //Exception ex = Assert.Throws<ArgumentNullException>(act);
            Assert.Throws<ArgumentOutOfRangeException>((Action)Act);
        }

        [Fact]
        public void PlaceOrder2_Default()
        {
            //"Order of {quantity} of {product.ProductCode}."
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order of 3 of Tools-1.");

            //Act
            var actual = vendor.PlaceOrder2(product, 3);

            //Assert
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void PlaceOrder2_3Params()
        {
            //"Order of {quantity} of {product.ProductCode}."
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order of 3 of Tools-1. Deliver by: 10/25/18");

            //Act
            var actual = vendor.PlaceOrder2(product, 3, new DateTimeOffset(2018, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            //Assert
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }



        [Fact]
        public void PlaceOrderChained_3Params()
        {
            //"Order of {quantity} of {product.ProductCode}."
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Order of 3 of Tools-1. Deliver by: 10/25/18");

            //Act
            var actual = vendor.PlaceOrderChain(product, 3, new DateTimeOffset(2018, 10, 25, 0, 0, 0, new TimeSpan(-7, 0, 0)));

            //Assert
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }



        [Fact]
        public void PlaceOrder_NamedArguments()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Chainsaw", "");
            var expected = new OperationResult(true, "Test with address");

            //Act
            //var actual = vendor.PlaceOrder_ParamAdjustment(product, 3, true, false);
            var actual =
                vendor.PlaceOrder_ParamAdjustment(product, quantity: 12, includeAddress: true, sendCopy: false);

            //Assert
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void PlaceOrder_NamedArguments2()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Chainsaw", "");
            var expected = new OperationResult(true, "Test with address with copy");

            //Act
            //var actual = vendor.PlaceOrder_ParamAdjustment(product, 3, true, true);
            var actual =
                vendor.PlaceOrder_ParamAdjustment(product, quantity: 12, includeAddress: true, sendCopy: true);

            //Assert
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }



        [Fact]
        public void PlaceOrder_EnumArguments()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Chainsaw", "");
            var expected = new OperationResult(true, "Test with address");

            //Act
            //var actual = vendor.PlaceOrder_ParamAdjustment(product, 3, true, false);
            var actual =
                vendor.PlaceOrder_ParamEnumAdjustment(product, quantity: 12, includeAddress: Vendor.IncludeAddress.Yes, sendCopy: Vendor.SendCopy.No);

            //Assert
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }


        [Fact]
        public void PlaceOrder_OptionalArguments()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Test with address with instructions");

            //Act
            var actual = vendor.PlaceOrder_OptionalParams(product, 12, Vendor.IncludeAddress.Yes);

            //Assert
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }

        [Fact]
        public void PlaceOrder_OptionalArguments2()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Saw", "");
            var expected = new OperationResult(true, "Test with instructions");

            //Act
            var actual = vendor.PlaceOrder_OptionalParams(product, 12, instructions: "suite 4");

            //Assert
            Assert.Equal(expected.Success, actual.Success);
            Assert.Equal(expected.Message, actual.Message);
        }
    }
}
