using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace COMMON
{
    public class MailSender
    {

        public static void SendEmail(string email, string subject, string message)
        {
           
                MailMessage sender = new MailMessage();
                sender.From = new MailAddress("mvcemail62@gmail.com", "EvimiKur");
                sender.To.Add(email);
                sender.Subject = subject;
                sender.Body = message;

                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("mvcemail62@gmail.com", "Bilgeadam34.");
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Send(sender);

            
            

            

        }
    }
}
