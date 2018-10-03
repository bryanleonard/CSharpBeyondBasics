using Acme.Common;
using System;
using Xunit;

namespace Acme.CommonTests
{
    public class EmailServiceTests
    {
        [Fact]
        public void SendMessage_Success()
        {
            var email = new EmailService();
            var expected = "Message sent: Test Message";

            var actual = email.SendMessage("Test Message","This is a test message", "info@abccorp.com");

            Assert.Equal(expected, actual);
        }
    }
}
