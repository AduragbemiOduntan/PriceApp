using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PriceApp_Application.Services.Interfaces;
using System.Net;
using System.Net.Mail;

namespace PriceApp_Application.Services.Implementation
{
    public class EmailService : IEmailService
    {
        public string GetPassword()
        {
            string path = "C:\\Users\\aduragbemi.oduntan\\Desktop\\JustProjects\\PriceApp\\PriceApp-API\\appsettings.json";
            using (StreamReader reader = File.OpenText(path))
            {
                JObject jsonObject = (JObject)JToken.ReadFrom(new JsonTextReader(reader));
                string appPw = jsonObject["AppPW"]?.ToString();
                return appPw;
            }
        }

        public async Task CreateEmail(string recieverEmail, string subject, string messageBody)
        {
            var senderEmail = "priceapplication@gmail.com";
            var appPW = GetPassword();

            var emailClient = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(senderEmail, appPW)
            };

            await emailClient.SendMailAsync(new MailMessage(from: senderEmail, to: recieverEmail, subject, messageBody));
        }
    }
}
