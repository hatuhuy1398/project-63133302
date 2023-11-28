using System.Web.Mvc;

namespace Project_63133302.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller = "Home_63133302", id = UrlParameter.Optional }
            , new[] { "Project_63133302.Areas.Admin.Controllers" }
				);
        }
    }
}