using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace SkypeNotifier
{
    public class MailSender
    {
        public static void SendEmail(string email, string emailMessage)
        {
            var fromAddress = new MailAddress(ConfigurationManager.AppSettings["FromAddress"]);
            var toAddress = new MailAddress(email);
            string fromPassword = ConfigurationManager.AppSettings["FromPassword"];
            const string subject = "Skype notification digest";
            string body = emailMessage;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = WebUtility.HtmlDecode(body)
            })
            {
                smtp.Send(message);
            }
        }
    }
}
