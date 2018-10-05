using System;
using Acme.Common;
using Xunit;

namespace Acme.CommonTests
{
    public class LoggingServiceTests
    {
        [Fact]
        public void LogAction_Success()
        {
            //var loggingService = new LoggingService();
            var expected = "Action: Test Action";

            var actual = LoggingService.LogAction("Test Action");

            Assert.Equal(expected, actual);
        }
    }
}

