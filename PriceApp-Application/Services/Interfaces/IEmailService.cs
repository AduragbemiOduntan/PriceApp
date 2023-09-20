namespace PriceApp_Application.Services.Interfaces
{
    public interface IEmailService
    {
        Task CreateEmail(string recieverEmail, string subject, string messageBody);
        Task<string> GenerateEmailConfirmationLinkAsync(string userId, string token, string scheme);
    }
}
