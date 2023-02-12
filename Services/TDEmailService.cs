using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using Twoishday.Models;

namespace Twoishday.Services
{
    public class TDEmailService : IEmailSender
    {
        private readonly MailSettings _mailSettings;

        public TDEmailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(string emailTo, string subject, string htmlMessage)
        {
            MimeMessage email = new();

            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));
            //email.Sender = MailboxAddress.Parse(_mailSettings.Email);
            email.To.Add(MailboxAddress.Parse(emailTo));
            email.Subject = subject;

            var builder = new BodyBuilder
            {
                HtmlBody = htmlMessage
            };

            email.Body = builder.ToMessageBody();

            try
            {
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.EmailHost, _mailSettings.EmailPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Email, _mailSettings.EmailPassword);

                await smtp.SendAsync(email);

                smtp.Disconnect(true);

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}
