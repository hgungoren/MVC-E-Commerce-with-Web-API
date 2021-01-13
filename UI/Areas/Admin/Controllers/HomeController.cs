using COMMON;
using MODEL.Context;
using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Utils;

namespace UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        AppUserService _appUserService = new AppUserService();
        AppDbContext db = new AppDbContext();
        // GET: Admin/Home
        [Authorize(Roles ="Admin")]
        public ActionResult Indexx()
        {
            //if (Session["Admin"] == null)
            //{
            //    return RedirectToAction("Login", "Home");
            //}
            //else
            //{
                var model = db.AppUsers.ToList();
                return View(model);
            //}
        }





        public ActionResult AdminIndex(AppUser model)
        {
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser model, HttpPostedFileBase imagePath)
        {
            //if (Session["Admin"] == null)
            //{
            //    return RedirectToAction("Login", "Home");
            //}

            //if (!ModelState.IsValid)
            //{
            //    return View("Register");
            //}




            model.ImagePath = ImageUploader.UploadImage("~/Content/user-image/", imagePath);

            var result = _appUserService.Any(x => x.Email == model.Email);
            if (result)
            {
                TempData["Error"] = $"{model.Email} daha önce kayıt edilmiş.";
                return View();
            }
            else
            {
                if (_appUserService.Any(x => x.UserName == model.UserName))
                {
                    TempData["Error"] = $"{model.UserName} daha önce kayıt edilmiş.";
                    return View();
                }
                else
                {
                    model.ActivationId = Guid.NewGuid();
                    _appUserService.Add(model);
                    string message = $"Yetkili kaydınız başarılı şekilde oluşturuldu.\nkayıt işlemini tamamlamak için lütfen aşağıdaki linki tıklayın.\n" + "https://localhost:44347/" + "Home/Complete/" + model.ActivationId;
                    MailSender.SendEmail(model.Email, "Kayıt İşlemi", message);
                    return RedirectToAction("AdminIndex", model);
                }

            }

        }

        //[HttpGet]
        public ActionResult Edit(Guid id)
        {



            if (id == null)
            {
                return HttpNotFound();
            }
            //var model = db.AppUsers.Find(id);

            AppUser person = db.AppUsers.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);

            //return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AppUser person, string Answer_1)
        {
            //_appUserService.Update(model);
            //TempData["Message"] = $"{model.Name} adlı kişi güncellendi";
            //return RedirectToAction("Indexx");


            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.Entry(person).Property(e => e.CreatedBy).IsModified = false;
            db.Entry(person).Property(e => e.CreatedDate).IsModified = false;
            person.ModifyBy = NameSurname;
            person.ModifyDate = DateTime.Now;
            if (Answer_1 == Constants.AnswerType.Yes)
            {
                person.IsAdmin = true;
            }
            else
            {
                person.IsAdmin = false;
            }
            db.SaveChanges();
            return RedirectToAction("Indexx");
        }

        public ActionResult UserDelete(Guid? Id)
        {
            //_appUserService.Remove(id);
            //TempData["Message"] = $"{id} no'lu kişi silindi";
            //return RedirectToAction("Indexx");

            //if (Id == null /*|| Id == 0*/)
            //{
            //    return HttpNotFound();
            //}

            var person = db.AppUsers.Find(Id);
            db.AppUsers.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Indexx");
        }

    }
}