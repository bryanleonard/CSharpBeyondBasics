using System;

namespace Acme.Common
{
    /// <summary>
    /// Provides logging.
    /// </summary>
    public static class LoggingService
    {
        public static string LogAction(string action)
        {
            var logText = $"Action: {action}";
            Console.WriteLine(logText);
            return logText;
        }
    }
}