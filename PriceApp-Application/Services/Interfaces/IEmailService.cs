using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp_Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task CreateEmail(string recieverEmail, string subject, string messageBody);
        Task<string> GenerateEmailConfirmationLinkAsync(string userId, string token, string scheme);
    }
}
