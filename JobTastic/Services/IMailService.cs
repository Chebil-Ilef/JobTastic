using JobTastic.Models;

namespace JobTastic.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendContactAsync(ContactMail contactMail);

    }
}
