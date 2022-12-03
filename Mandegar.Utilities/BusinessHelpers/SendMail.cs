using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Threading.Tasks;
using Mandegar.Utilities.Extensions;
using Mandegar.Utilities.Interfaces;
using Mandegar.Utilities.Models;

namespace Mandegar.Utilities.BusinessHelpers
{
    public class SendMail : ISendMail
    {
        private readonly EmailOptionVM emailOption = new();
        private readonly IConfiguration configuration;

        public SendMail(IConfiguration configuration)
        {
            this.configuration = configuration;

            emailOption.Host = this.configuration["Email:Server"];
            emailOption.Port = this.configuration["Email:Port"].ToInt();
            emailOption.From = this.configuration["Email:SenderEmail"];
            emailOption.UserName = this.configuration["Email:UserName"];
            emailOption.Password = this.configuration["Email:Password"];
            emailOption.IsSSL = this.configuration["Email:Security"].ToBoolean();

        }

        public async Task<bool> SendAsync(string to, string subject, string body)
        {
            this.emailOption.To = to;
            this.emailOption.Subject = subject;
            this.emailOption.Body = body;
            return await SendAsync();
        }

        public async Task<bool> SendAsync()
        {
            MailMessage mail = new();

            mail.To.Add(this.emailOption.To);
            mail.From = new MailAddress(this.emailOption.From);
            mail.Subject = this.emailOption.Subject;
            mail.Body = this.emailOption.Body;
            mail.IsBodyHtml = this.emailOption.IsHTML;

            SmtpClient client = new()
            {
                Host = this.emailOption.Host,
                Port = this.emailOption.Port,
                Credentials = new System.Net.NetworkCredential
                    (this.emailOption.UserName, this.emailOption.Password),
                EnableSsl = this.emailOption.IsSSL
            };
            client.SendAsync(mail, null);
            return true;
        }
    }
}