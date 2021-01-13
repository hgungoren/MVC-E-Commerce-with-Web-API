using System.Web.Mvc;

namespace UI.Areas.Halklaİliskiler
{
    public class HalklaİliskilerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Halklaİliskiler";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Halklaİliskiler_default",
                "Halklaİliskiler/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}