using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PriceApp_Application.Services.Interfaces;

namespace PriceApp_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("emailSender")]
        public async Task<IActionResult> CreateMail(string recieverEmail, string subject, string messageBody)
        {
              await _emailService.CreateEmail(recieverEmail, subject, messageBody);
            return Ok("Mail has been succeefully sent");
        }
    }
}
