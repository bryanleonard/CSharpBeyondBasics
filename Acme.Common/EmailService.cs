namespace Acme.Common
{
    /// <summary>
    ///     Provides service to send email
    /// </summary>
    public class EmailService
    {
        /// <summary>
        /// Sends email message.
        /// </summary>
        /// <param name="subject">Message subject</param>
        /// <param name="message">The message itself</param>
        /// <param name="recipient">The receiver of the message.</param>
        /// <returns></returns>
        public string SendMessage(string subject, string message, string recipient)
        {
            var confirmation = $"Message sent: {subject}";
            var loggingService = new LoggingService();
            loggingService.LogAction(confirmation);
            return confirmation;
        }
    }
}