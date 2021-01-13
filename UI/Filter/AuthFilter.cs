using CORE.CoreEntity.Enums;
using EnvDTE;
using MODEL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace UI.Filter
{
    public class AuthFilter : /*Controller*/ FilterAttribute, IAuthorizationFilter
    {
        public AppDbContext db = new AppDbContext();
        public string UserCode { get; set; }
        public string NameSurname { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["User"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/Login");
            }
        }



        //public AppDbContext db = new AppDbContext();
        //public string UserCode { get; set; }
        //public string NameSurname { get; set; }
        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{

        //    if (Session["User"] == null)
        //    {
        //        filterContext.Result = new RedirectResult("~/Home/Login");
        //    }
        //    else
        //    {
        //        UserCode = Session["User"].ToString();
        //        NameSurname = Session["Password"].ToString();
        //    }
        //    base.OnActionExecuting(filterContext);
        //}



    }
   
}