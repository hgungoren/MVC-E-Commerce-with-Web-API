using COMMON;
using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Halklaİliskiler.Controllers
{
    public class ContactController : Controller
    {
        ContactService _contactService = new ContactService();
        SenderMessageService _senderMessageService = new SenderMessageService();

        // GET: Halklaİliskiler/Contact
        public ActionResult Index()
        {
            return View(_contactService.GetAll());
        }

        public ActionResult Reply(Guid id)
        {
            
            var getById = _senderMessageService.GetById(id);
            return View(getById);
        }


        [HttpPost]
        public ActionResult Reply(SenderMessage senderMessage, string email)
        {
            if (ModelState.IsValid)
            {

                senderMessage.Date = DateTime.Now;
                SenderMessageService _senderMessageService = new SenderMessageService();
                senderMessage.ID = new Guid();

                if (Session["User"] == null)
                {
                    TempData["Basarisiz"] = "Lütfen önce giriş yapmayı deneyiniz.";
                    return RedirectToAction("Login", "Home");

                }


                TempData["Basarili"] = "Mesaj Gönderildi.";
                //string message = "Şİkayetinizi/görüşünüzü";
                MailSender.SendEmail(senderMessage.Email, "EvimiKur", senderMessage.Message);
                _senderMessageService.Add(senderMessage);

                return RedirectToAction("Reply", senderMessage);

            }
            return View();
        }
    }
}