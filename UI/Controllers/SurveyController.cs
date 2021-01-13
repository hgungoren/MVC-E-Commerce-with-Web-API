using MODEL.Context;
using MODEL.Entities;
using SERVICE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        AppUserService _appUserService = new AppUserService();
        AppDbContext db = new AppDbContext();
        public ActionResult Index(string Code)
        {

            if (Code == null)
            {
                //List<SelectListItem> personList = (from person in db.AppUsers
                //                                   where person.Email != UserName
                //                                   select new SelectListItem
                //                                   {
                //                                       Text = person.UserName,
                //                                       Value = person.Code.ToString()
                //                                   }).ToList();
                //ViewBag.Person = new SelectList(personList.OrderBy(m => m.Text), "Value", "Text");

                if (Session["User"] == null)
                {
                    TempData["Basarisiz"] = "Lütfen önce giriş yapmayı deneyiniz.";
                    return RedirectToAction("Login", "Home");

                }


                var questionModel = db.Questions.ToList();
                return View(questionModel);
            }

            else
            {
                //CalculateScore(Code);
                return RedirectToAction("Index");
            }

        }

        public void CalculateScore(string code)
        {
            double answeryes = 0, answerno = 0, scoreresult = 0;
            var answer = db.AppUsers.FirstOrDefault(m => m.Email == code && m.UserName == User.ToString());
            var answerLine = db.AnswerLines.Where(m => m.AppUserId == answer.ID).ToList();

            foreach (var item in answerLine)
            {
                if (item.AppUser.ToString() == Constants.AnswerType.Yes)
                    answeryes++;
                else
                    answerno++;

            }
            scoreresult = (answeryes / (answeryes + answerno)) * 100;
            if (scoreresult > 79)
            {
                answer.Iscomplete = true;
            }
            else
            {
                answer.Iscomplete = false;
            }
            answer.Score = scoreresult.ToString();
            db.SaveChanges();

        }

        public String SendData(AnswerModel answerModel)
        {
            int? month = DateTime.Now.Month;
            var model = db.AppUsers.FirstOrDefault(m => m.Email == answerModel.Email.Email && m.UserName == User.ToString() && m.CreatedDate.Value.Month == month);


            if (model != null)
            {
                SaveAnswerLine(answerModel.Question, answerModel.AppUser, model.ID);
            }
            else
            {
                AppUser answer = new AppUser();
                answer.Email = answerModel.Email.Email;
                answer.PersonName = answerModel.NameSurname;
                answer.UserName = User.ToString();
                answer.CreatedDate = DateTime.Now;
                answer.CreatedBy = User.ToString();

                //db.AppUsers.Add(answer);
                //db.SaveChanges();
                _appUserService.Add(answer);

                //SaveAnswerLine(answerModel.Question, answerModel.Answer, answer.ID);
            }
            return "True";
        }

        public void SaveAnswerLine(string question, AppUser answer, Guid answerId)
        {

            var model = db.AnswerLines.FirstOrDefault(m => m.AppUserId == answerId && m.Question == question);

            if (model != null)
            {
                model.AppUser = answer;
                db.SaveChanges();
            }
            else
            {
                AnswerLine answerLine = new AnswerLine();
                answerLine.AppUserId = answerId;
                answerLine.AppUser = answer;
                answerLine.Question = question;
                db.AnswerLines.Add(answerLine);
                db.SaveChanges();
            }


        }
    }
}