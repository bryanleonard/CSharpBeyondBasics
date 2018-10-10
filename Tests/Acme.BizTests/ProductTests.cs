using System;
using System.Linq;
using Acme.Biz;
using Xunit;
using Xunit.Abstractions;

namespace Acme.BizTests
{
    public class ProductTests
    {
        [Fact]
        public void SayHelloTest()
        {
            // Had to use set properties method for Company name :|
            var currProd = new Product();
            currProd.ProductId = 1;
            currProd.ProductName = "Saw";
            currProd.Description = "15-inch steel blade hand saw";
            currProd.ProductVendor.CompanyName = "Hi Corp!";

            //Arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15-inch steel blade hand saw"
            };

            //Act
            //var actual = currentProduct.SayHello();
            var actual = currProd.SayHello();
            var expected = "Hello (1) Saw: 15-inch steel blade hand saw, Available on: ";

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SayHello_ParameterizedConstructor()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");

            //Act
            var actual = currentProduct.SayHello();
            var expected = "Hello (1) Saw: 15-inch steel blade hand saw, Available on: ";

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;
            string expected = null;

            //Act
            var actual = companyName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ConvertMetersToInches()
        {
            //Arrange
            var expected = 78.74;

            //Act
            var actual = 2 * Product.InchesPerMeter;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MinimumPriceTest_Default()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = .96m;

            //Act
            var actual = currentProduct.MiniumPrice;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void MinimumPriceTest_Bulk()
        {
            //Arrange
            var currentProduct = new Product(1, "Bulk", "");
            var expected = 9.96m;

            //Act
            var actual = currentProduct.MiniumPrice;

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
