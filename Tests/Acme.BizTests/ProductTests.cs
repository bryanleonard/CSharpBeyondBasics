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
            //Arrange
            var currentProduct = new Product
            {
                ProductId = 1,
                ProductName = "Saw",
                Description = "15-inch steel blade hand saw"
            };

            //Act
            var actual = currentProduct.SayHello();
            var expected = "Hello (1) Saw: 15-inch steel blade hand saw";

            //Asset
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void SayHello_ParameterizedConstructor()
        {
            //Arrange
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");

            //Act
            var actual = currentProduct.SayHello();
            var expected = "Hello (1) Saw: 15-inch steel blade hand saw";

            //Asset
            Assert.Equal(expected, actual);
        }
    }
}
