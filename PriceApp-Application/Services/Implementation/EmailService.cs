using PriceApp_Application.SeriviceMethods.Implementations;
using PriceApp_Application.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace PriceApp_Application.Services.Implementation
{
    public class EmailService : IEmailService
    {
        public async Task CreateEmail(string recieverEmail, string subject, string messageBody)
        {
            var senderEmail = "priceapplication@gmail.com";
            var appPW = StaticMethods.GetAppPassword();

            var emailClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, appPW)
            };

            await emailClient.SendMailAsync(new MailMessage(from: senderEmail, to: recieverEmail, subject, messageBody));
        }

        public async Task<string> GenerateEmailConfirmationLinkAsync(string userEmail, string token, string scheme)
        {
            // Build the confirmation link URL
            var confirmationLink = $"{scheme}://localhost:7297/api/Authentication/confirm-email/?email={userEmail}&token={WebUtility.UrlEncode(token)}";

            return confirmationLink;
        }
    }
}
