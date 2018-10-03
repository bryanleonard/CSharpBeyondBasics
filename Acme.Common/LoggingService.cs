using System;

namespace Acme.Common
{
    /// <summary>
    /// Provides logging.
    /// </summary>
    public class LoggingService
    {
        public string LogAction(string action)
        {
            var logText = $"Action: {action}";
            Console.WriteLine(logText);
            return logText;
        }
    }
}