using MODEL.Context;
using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Constants;
using UI.Filter;
using UI.Models;
using UI.Utils;

namespace UI.Areas.Halklaİliskiler.Controllers
{
    public class AnswerController : BaseController
    {
        QuestionService _questionService = new QuestionService();
        AnswerService _answerService = new AnswerService();
        //AnswerLineService _answerLineService = new AnswerLineService();
        AppUserService _appUserService = new AppUserService();

        AppUser AppUser = new AppUser();


        public ActionResult Index()
        {

            var model = db.AppUsers.Where(m => m.UserName == UserName).ToList();

            return View(model);

        }


        //public ActionResult Create(string Code)
        //{

        //    if (Code == null)
        //    {
        //        //List<SelectListItem> personList = (from person in db.AppUsers
        //        //                                   where person.Email != UserName
        //        //                                   select new SelectListItem
        //        //                                   {
        //        //                                       Text = person.UserName,
        //        //                                       Value = person.Code.ToString()
        //        //                                   }).ToList();
        //        //ViewBag.Person = new SelectList(personList.OrderBy(m => m.Text), "Value", "Text");



        //        var questionModel = db.Questions.ToList();
        //        return View(questionModel);
        //    }

        //    else
        //    {
        //        //CalculateScore(Code);
        //        return RedirectToAction("Index");
        //    }

        //}


        //public void CalculateScore(string code)
        //{
        //    double answeryes = 0, answerno = 0, scoreresult = 0;
        //    var answer = db.AppUsers.FirstOrDefault(m => m.Email == code && m.UserName == UserName);
        //    var answerLine = db.AnswerLines.Where(m => m.AppUserId == answer.ID).ToList();

        //    foreach (var item in answerLine)
        //    {
        //        if (item.AppUser.ToString() == Constants.AnswerType.Yes)
        //            answeryes++;
        //        else
        //            answerno++;

        //    }
        //    scoreresult = (answeryes / (answeryes + answerno)) * 100;
        //    if (scoreresult > 79)
        //    {
        //        answer.Iscomplete = true;
        //    }
        //    else
        //    {
        //        answer.Iscomplete = false;
        //    }
        //    answer.Score = scoreresult.ToString();
        //    db.SaveChanges();

        //}


        //public String SendData(AnswerModel answerModel)
        //{
        //    int? month = DateTime.Now.Month;
        //    var model = db.AppUsers.FirstOrDefault(m => m.Email == answerModel.Email.Email && m.UserName == UserName && m.CreatedDate.Value.Month == month);


        //    if (model != null)
        //    {
        //        SaveAnswerLine(answerModel.Question, answerModel.AppUser, model.ID);
        //    }
        //    else
        //    {
        //        AppUser answer = new AppUser();
        //        answer.Email = answerModel.Email.Email;
        //        answer.PersonName = answerModel.NameSurname;
        //        answer.UserName = UserName;
        //        answer.CreatedDate = DateTime.Now;
        //        answer.CreatedBy = NameSurname;

        //        //db.AppUsers.Add(answer);
        //        //db.SaveChanges();
        //        _appUserService.Add(answer);

        //        //SaveAnswerLine(answerModel.Question, answerModel.Answer, answer.ID);
        //    }
        //    return "True";
        //}


        //[HttpPost]
        //public void SaveAnswerLine(string question, AppUser answer, Guid answerId)
        //{

        //    var model = db.AnswerLines.FirstOrDefault(m => m.AppUserId == answerId && m.Question == question);

        //    if (model != null)
        //    {
        //        model.AppUser = answer;
        //        db.SaveChanges();
        //    }
        //    else
        //    {
        //        AnswerLine answerLine = new AnswerLine();
        //        answerLine.AppUserId = answerId;
        //        answerLine.AppUser = answer;
        //        answerLine.Question = question;
        //        db.AnswerLines.Add(answerLine);
        //        db.SaveChanges();
        //    }


        //}

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            AppUser answer_details = db.AppUsers.Find(id);
            if (answer_details == null)
            {
                return HttpNotFound();
            }
            return View(answer_details);
        }

        public ActionResult Detail(Guid? Id)
        {
            //var model = _answerLineService.GetDefault(m => m.AnswerId == Id);

            var model = db.AnswerLines.Where(m => m.AppUserId == Id).ToList();
            return View(model);
        }

    }
}