using System;
using Xunit;
using Acme.Biz;

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
    }
}
