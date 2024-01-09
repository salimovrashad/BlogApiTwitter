using GTwitt.BUSINESS.ExternalServices.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace GTwitt.BUSINESS.ExternalServices.Implements
{
	public class EmailServices : IEmailServices
    {
        IConfiguration _configuration { get; }

        public EmailServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Send(string toMail, string header, string body, bool isHtml = true)
        {
            SmtpClient smtpClient = new SmtpClient(_configuration["Email:Host"], Convert.ToInt32(_configuration["Email:Port"]));
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]);

            MailAddress from = new MailAddress(_configuration["Email:Username"], "Twitter support");
            MailAddress to = new MailAddress(toMail);

            MailMessage message = new MailMessage(from, to);
            message.Body = body;
            message.Subject = header;
            message.IsBodyHtml = isHtml;

            smtpClient.Send(message);
        }
    }
}
