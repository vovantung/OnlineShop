using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Common1
{
    public class MailHelper
    {
        public void SendMail(string subject, string content, string toMailAddress)
        {
            var FromMailAddress = ConfigurationManager.AppSettings["FormMailAddress"].ToString();
            var FromMailPassword = ConfigurationManager.AppSettings["bungteDT12345"].ToString();
            var FromMailDisplay = ConfigurationManager.AppSettings["FormMailDisplay"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();
            bool enableSSL = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());
            string body = content;
            MailMessage mesage = new MailMessage(new MailAddress(FromMailAddress, FromMailDisplay), new MailAddress(toMailAddress));
            mesage.Subject = subject;
            mesage.Body = body;
            mesage.IsBodyHtml = true;
            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(FromMailAddress, FromMailPassword);
            client.Host = smtpHost;
            client.EnableSsl = enableSSL;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(mesage);

        }
    }
}
