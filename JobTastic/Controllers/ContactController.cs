using JobTastic.Models;
using JobTastic.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobTastic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly ILogger<ContactController> logger;

        public ContactController(IMailService mailService, ILogger<ContactController> logger)
        {
            this.mailService = mailService;
            this.logger = logger;
        }

        [HttpPost("contact")]
        public async Task<IActionResult> ContactMail([FromBody] ContactMail contactMail)
        {
            try
            {
                contactMail.ToEmail = "ilefchebile@gmail.com";
                logger.LogInformation("SendMail method called.");
                await mailService.SendContactAsync(contactMail);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error in SendMail method.");
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}