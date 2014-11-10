using System.Web.Mvc;

namespace Test.Areas.Site
{
    public class SiteAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Site";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Site_default",
				"",
				new { area = "Site", controller = "Person", action = "Index" }
            );

			//context.MapRoute(
			//	"Site_defaultWithParams",
			//	"{page}/{Search}",
			//	new { area = "Site", controller = "Person", action = "Index", page = 1, search = string.Empty}
			//);
        }
    }
}