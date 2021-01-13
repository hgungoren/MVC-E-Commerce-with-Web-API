using SERVICE.Repository;
using SERVICE.ViewModels.AppUserVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Halklaİliskiler.Controllers
{
    public class HomeController : Controller
    {
        AppUserService _appUserService = new AppUserService();
        ContactService _contactService = new ContactService();
        // GET: Halklaİliskiler/Home
        [Authorize(Roles ="HalklaIliskiler,Admin")]
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Login()
        //{

        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Login(LoginVM loginVM)
        //{

        //    if (ModelState.IsValid)
        //    {


        //        var result = _appUserService.Login(loginVM);
        //        if (result)
        //        {

        //            var user = _appUserService.GetUser(loginVM);

        //            Session["User"] = user;

        //            return RedirectToAction("Index", "Home");
        //        }
        //        else
        //        {
        //            ViewBag.Error = "Kullanıcı bulunamadı";
        //            return View();
        //        }



        //    }
        //    return View(loginVM);
        //}
    }
}