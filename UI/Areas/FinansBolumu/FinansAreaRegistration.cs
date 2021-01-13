using System.Web.Mvc;

namespace UI.Areas.FinansBolumu
{
    public class FinansBolumuAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "FinansBolumu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "FinansBolumu_default",
                "FinansBolumu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}