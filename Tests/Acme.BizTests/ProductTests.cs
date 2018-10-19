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
            var currentProduct = new Product(1, "Bulk Stuff", "");
            var expected = 9.96m;

            //Act
            var actual = currentProduct.MiniumPrice;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductName_Format()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "   Divine Hammer   ";
            //var currentProduct = new Product { ProductName = "   10-Ton Divine Hammer   "};
            var expected = "Divine Hammer";

            //Act
            var actual = currentProduct.ProductName;

            //Assert
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ProductName_TooShort()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";
            string expected = null;
            string expectedMessage = "Product name must be at least 3 characters.";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void ProductName_TooLong()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "TheFlibbertyJibbersWhatSoFunnyAboutAName";
            string expected = null;
            string expectedMessage = "Product name must be less than 20 characters.";

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }


        [Fact]
        public void ProductName_JustRight()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "     Flibberty Jibbers   ";
            string expected = "Flibberty Jibbers";
            string expectedMessage = null;

            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.Equal(expected, actual);
            Assert.Equal(expectedMessage, actualMessage);
        }

        [Fact]
        public void Category_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = "Tools";

            //Act
            var actual = currentProduct.ProductCategory;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Category_NewValue()
        {
            //Arrange
            var currentProduct = new Product
            {
                ProductCategory = "Garden"
            };
            var expected = "Garden";

            //Act
            var actual = currentProduct.ProductCategory;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sequence_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = 1;

            //Act
            var actual = currentProduct.SequenceNumber;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sequence_NewValue()
        {
            //Arrange
            var currentProduct = new Product
            {
                SequenceNumber = 20
            };
            var expected = 20;

            //Act
            var actual = currentProduct.SequenceNumber;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ProductCode_Default()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = "Tools-1";

            //Act
            var actual = currentProduct.ProductCode;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CalculateSuggestedPrice()
        {
            //Arrange
            var currentProduct = new Product{
                ProductId = 1,
                ProductName = "Saw",
                Description = "",
                ProductCost = 50m
            };
            var expected = 55m;

            //Act
            var actual = currentProduct.CalculateSuggestedPrice(10m);

            //Assert
            Assert.Equal(expected, actual);
        }

    }
}
