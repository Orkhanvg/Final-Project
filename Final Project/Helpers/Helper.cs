using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Final_Project.Helpers
{
    public class Helper
    {
       
            private readonly string _email;
            public readonly string _password;

            public Helper(string email, string password)
            {
                _email = email;
                _password = password;
            }

            public static void DeleteImage(string path)
            {
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            public enum UserRoles
            {
                Member
            }

        //confirm email 
            public bool SendEmail(string email, string confirmation)
            {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_email);
            message.To.Add(new MailAddress(email));


            message.Subject = "Confirm Email";
            message.Body = confirmation;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(_email, _password);

                client.Host = "smtp.mail.ru";
                client.Port = 587;
                client.EnableSsl = true;
                try
                {
                    client.Send(message);
                }
                catch (System.Exception)
                {

                }
                return false;
            }
        //email for new product
            public bool SendNews(string email, string confirmation)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_email);
                message.To.Add(new MailAddress(email));

                message.Subject = "New Product";
                message.Body = confirmation;
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(_email, _password);

                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                try
                {
                    client.Send(message);
                }
                catch (System.Exception)
                {

                }
                return false;
            }


        //email for discount products

            public bool DiscountPrice(string email, string confirmation)
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(_email);
                message.To.Add(new MailAddress(email));

                message.Subject = "On Discount";
                message.Body = confirmation;
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient();
                client.Credentials = new System.Net.NetworkCredential(_email, _password);

                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                try
                {
                    client.Send(message);
                }
                catch (System.Exception)
                {

                }
                return false;
            }
        }

    }
