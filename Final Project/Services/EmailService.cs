using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Final_Project.Services
{
    public class EmailService
    {
        private readonly string _email;
        private readonly string _password;

        public EmailService(string email, string password)
        {
            _email = email;
            _password = password;
        }


        public bool SendEmail(string UserEmail, string subject, string content, byte[] bytes = null, string filename = null)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_email);
            mailMessage.To.Add(new MailAddress(UserEmail));

            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = content;
            

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(_email, _password);
            client.Host = "smtp.mail.ru";
            client.EnableSsl = true;
            client.Port = 587;

            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (System.Exception)
            {


            }

            return false;
        }
    }

}
