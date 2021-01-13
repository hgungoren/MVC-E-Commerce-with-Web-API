using MODEL.Context;
using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Utils;

namespace UI.Areas.Halklaİliskiler.Controllers
{
    public class QuestionController : BaseController
    {
        QuestionService _questionService = new QuestionService();
        // GET: Halklaİliskiler/Question
        public ActionResult Index()
        {
            //if (Session["User"] == null)
            //{
            //    TempData["Basarisiz"] = "Lütfen önce giriş yapmayı deneyiniz.";
            //    return RedirectToAction("Login", "Home");

            //}
            //else
            //{
                var model = db.Questions.ToList();
                //var model = _questionService.GetAll();
                return View(model);
            //}
        }

        public ActionResult Create(Question question)
        {
            if (question.QuestionLine != null)
            {
                question.ID = new Guid();
                question.CreatedDate = DateTime.Now;
                question.CreatedBy = NameSurname;
                //db.Questions.Add(question);
                //db.SaveChanges();
                _questionService.Add(question);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(Guid Id)
        {
            
            if (Id == null )
            {
                return HttpNotFound();
            }
            var model = db.Questions.Find(Id); 
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Question question)
        {
            db.Entry(question).State = System.Data.Entity.EntityState.Modified;
            db.Entry(question).Property(e => e.CreatedBy).IsModified = false;
            db.Entry(question).Property(e => e.CreatedDate).IsModified = false;
            question.ModifyBy = NameSurname;
            question.ModifyDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid? Id)
        {
            if (Id == null /*|| Id == Guid.Empty*/)
            {
                return HttpNotFound();
            }
            //var question = _questionService.GetById(Id);
            var question = db.Questions.Find(Id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}