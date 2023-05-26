using HR.LeaveManagement.Application.Contracts.Email;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveManagement.Application.Models.Email;

namespace HR.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        public EmailSettings _emailSettings { get; }
        public EmailSender(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }
        public async ValueTask<bool> SendEmail(EmailMessage email)
        {
            return await SendMailClientAsync(email.To, email.Subject, email.Body);
        }

        public ValueTask<bool> SendMailClientAsync(string toEmail, string subject, string body)
        {
            MailMessage mail = new MailMessage
            (
                _emailSettings.FromAddress, toEmail, subject, body
            );
            mail.IsBodyHtml = true;
            try
            {
                using (var smtp = new SmtpClient())
                {
                    // AAB
                    smtp.Host = _emailSettings.SmtpHost;
                    smtp.Port = int.Parse(_emailSettings.SmtpPort);
                    smtp.Credentials = new NetworkCredential(_emailSettings.SmtpCredUsername, _emailSettings.SmtpCredPassword);

                    //// Smart
                    //smtp.Host = "mail.ankpos.com";
                    //smtp.Port = 25;
                    //smtp.Credentials = new NetworkCredential("", "");

                    smtp.Send(mail);
                    mail = null;
                }

                return ValueTask.FromResult(true);
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                return ValueTask.FromResult(false);
            }
        }
    }
}
