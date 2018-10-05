using Acme.Common;

namespace Acme.Biz
{
    /// <summary>
    ///     Manages the vendors we purchase inventory from
    /// </summary>
    public class Vendor
    {

        #region Properties
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        #endregion

        #region Methods
        /// <summary>
        ///     Sends an email to welcome new vendor
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public string SendWelcomeEmail(string message)
        {
            var emailService = new EmailService();
            var subject = ($"Hello {this.CompanyName}").Trim();
            var confirmation = emailService.SendMessage(subject, message, this.Email);

            return confirmation;
        }
        #endregion
    }
}