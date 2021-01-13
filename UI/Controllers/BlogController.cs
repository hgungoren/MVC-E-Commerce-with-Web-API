using COMMON;
using MODEL.Context;
using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace UI.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Contact contact, string email)
        {
            if (ModelState.IsValid)
            {

                contact.Date = DateTime.Now;
                ContactService _contactService = new ContactService();
                contact.ID = new Guid();


                if (Session["User"] == null)
                {
                    TempData["Basarisiz"] = "Lütfen önce giriş yapmayı deneyiniz.";
                    return RedirectToAction("Login", "Home");

                }

                TempData["Basarili"] = "Teşekkürler en kısa zamanda tarafınıza dönüş yapılacaktır";
                string message = "Şİkayetinizi/görüşünüzü bize ilettiğiniz için teşekkür ederiz. En kısa zamanda tarafınıza dönüş yapılacaktır. Sağlıklı günler ve bol kazançlar dileriz.";
                MailSender.SendEmail(contact.Email, "EvimiKur", message);
                _contactService.Add(contact);

                return RedirectToAction("Index", contact);
            }

            return View();






            //MailMessage mail = new MailMessage();
            //mail.SubjectEncoding = Encoding.Default; //karakter hataları vs. bunların önüne geçmek için kullanıldı(encoding)
            //mail.Subject = contact.Name;
            //mail.BodyEncoding = Encoding.Default;
            //mail.Body = contact.Message;

            //mail.From = new MailAddress(ConfigurationManager.AppSettings["EmailAccount"]);
            //mail.To.Add(email);


            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Host = ConfigurationManager.AppSettings["smtp.gmail.com"];
            //smtpClient.Port = int.Parse(ConfigurationManager.AppSettings[587]);
            //smtpClient.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["mvcemail62@gmail.com"], ConfigurationManager.AppSettings["Bilgeadam62"]);
            //smtpClient.EnableSsl = bool.Parse(ConfigurationManager.AppSettings[""]);
            //smtpClient.Send(mail);

            //TempData["Başarılı"] = "Teşekkürler en kısa zamanda tarafınıza dönüş yapılacaktır";



        }

    }
}