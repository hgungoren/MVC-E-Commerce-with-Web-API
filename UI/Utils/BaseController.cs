using MODEL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Utils
{
    public class BaseController : Controller
    {
        public AppDbContext db = new AppDbContext();
        public string UserName { get; set; }
        public string NameSurname { get; set; }
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{

        //    if (Session["Code"] == null)
        //    {
        //        filterContext.Result = new RedirectResult("/Home/Login");
        //    }
        //    else
        //    {
        //        UserCode = Session["Code"].ToString();
        //        NameSurname = Session["NameSurname"].ToString();
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
    }
}