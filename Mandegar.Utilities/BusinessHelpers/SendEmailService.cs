using Mandegar.Utilities.Interfaces;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Mandegar.Utilities.BusinessHelpers
{
    public class SendEmailService : ISendEmailService
    {

        public async Task SendAsync(string to, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(AppsettingsGetter.Get("Email:Server"));
            mail.From = new MailAddress(AppsettingsGetter.Get("Email:SenderEmail"), AppsettingsGetter.Get("Email:SenderName"));
            foreach (var item in to.Split(','))
            {
                if (Validations.IsValidEmail(item))
                {
                    mail.To.Add(item);
                }
            }

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = int.Parse(AppsettingsGetter.Get("Email:Port"));
            SmtpServer.Credentials = new System.Net.NetworkCredential(AppsettingsGetter.Get("Email:UserName"), AppsettingsGetter.Get("Email:Password"));
            SmtpServer.EnableSsl = bool.Parse(AppsettingsGetter.Get("Email:Security"));

            await SmtpServer.SendMailAsync(mail);
        }
    }
}