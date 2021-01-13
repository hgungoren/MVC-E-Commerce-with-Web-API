using System.Web.Mvc;

namespace UI.Areas.InsanKaynaklari
{
    public class InsanKaynaklariAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "InsanKaynaklari";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "InsanKaynaklari_default",
                "InsanKaynaklari/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}