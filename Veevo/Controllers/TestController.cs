using Microsoft.AspNetCore.Mvc;
using Veevo.BLL.Interfaces;

namespace Veevo.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private IMailService _mailService;
        public TestController(IMailService mailService)
        { 
            _mailService = mailService;
        }
        [HttpPost("SendEmail")]
        public IActionResult SendEmailMessage(string email, string code)
        {
            _mailService.SendConfirmationEmailAsync(email, code);

            return Ok();
        }

    }
}
