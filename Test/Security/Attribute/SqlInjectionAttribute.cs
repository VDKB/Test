using System.Web;
using System.Web.Mvc;

namespace Test.Security.Attribute
{
	public class SqlInjectionAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			var screening = new SqlInjectionScreeningModule();
			screening.BeginRequest(HttpContext.Current.Request);
		}
	}
}