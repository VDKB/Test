using System;
using System.Web;

namespace Test.Security
{
	public class SqlInjectionScreeningModule : IHttpModule
	{
		public static string[] BlackList = {"char ","nchar ","varchar ","nvarchar ",
                                           "alter ","create ","cursor ","declare ","delete ","drop ","exec ","execute ",
                                           "fetch ","insert ","kill ",
                                           "select ", "sys ","sysobjects ","syscolumns ",
                                           "table ","update "};


		public void Dispose()
		{
			//no-op 
		}

		//Tells ASP.NET that there is code to run during BeginRequest
		public void Init(HttpApplication app)
		{
			app.BeginRequest += app_BeginRequest;
		}

		//For each incoming request, check the query-string, form and cookie values for suspicious values.
		public void BeginRequest(HttpRequest request)
		{
			foreach (string key in request.QueryString)
				CheckInput(request.QueryString[key], "QueryString");
			foreach (string key in request.Form)
				CheckInput(request.Form[key], "Form");
			foreach (string key in request.Cookies)
				CheckInput(request.Cookies[key].Value, "Cookies");
		}

		//For each incoming request, check the query-string, form and cookie values for suspicious values.
		private void app_BeginRequest(object sender, EventArgs e)
		{
			var request = (sender as HttpApplication).Context.Request;

			foreach (string key in request.QueryString)
				CheckInput(request.QueryString[key], "QueryString");
			foreach (string key in request.Form)
				CheckInput(request.Form[key], "Form");
			foreach (string key in request.Cookies)
				CheckInput(request.Cookies[key].Value, "Cookies");
		}

		//The utility method that performs the blacklist comparisons
		//You can change the error handling, and error redirect location to whatever makes sense for your site.
		private void CheckInput(string parameter, string source)
		{
			for (int i = 0; i < BlackList.Length; i++)
			{
				if ((parameter.IndexOf(BlackList[i], StringComparison.OrdinalIgnoreCase) >= 0))
				{
					HttpContext.Current.Response.End();
				}
			}
		}
	}
}