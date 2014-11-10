using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace Helpers
{
	public static class PagingExtensions
	{
		#region HtmlHelper extensions

		public static string Pager(this HtmlHelper htmlHelper, int PageSize, int PageNumber, int TotalItemCount)
		{
			return Pager(htmlHelper, PageSize, PageNumber, TotalItemCount, null, null);
		}

		public static string Pager(this HtmlHelper htmlHelper, int PageSize, int PageNumber, int TotalItemCount, string actionName)
		{
			return Pager(htmlHelper, PageSize, PageNumber, TotalItemCount, actionName, null);
		}

		public static string Pager(this HtmlHelper htmlHelper, int PageSize, int PageNumber, int TotalItemCount, object values)
		{
			return Pager(htmlHelper, PageSize, PageNumber, TotalItemCount, null, new RouteValueDictionary(values));
		}

		public static string Pager(this HtmlHelper htmlHelper, int PageSize, int PageNumber, int TotalItemCount, string actionName, object values)
		{
			return Pager(htmlHelper, PageSize, PageNumber, TotalItemCount, actionName, new RouteValueDictionary(values));
		}

		public static string Pager(this HtmlHelper htmlHelper, int PageSize, int PageNumber, int TotalItemCount, RouteValueDictionary valuesDictionary)
		{
			return Pager(htmlHelper, PageSize, PageNumber, TotalItemCount, null, valuesDictionary);
		}

		public static string Pager(this HtmlHelper htmlHelper, int PageSize, int PageNumber, int TotalItemCount, string actionName, RouteValueDictionary valuesDictionary)
		{
			if (valuesDictionary == null)
			{
				valuesDictionary = new RouteValueDictionary();
			}
			if (actionName != null)
			{
				if (valuesDictionary.ContainsKey("action"))
				{
					throw new ArgumentException("The valuesDictionary already contains an action.", "actionName");
				}
				valuesDictionary.Add("action", actionName);
			}
			var pager = new Pager(htmlHelper.ViewContext, PageSize, PageNumber, TotalItemCount, valuesDictionary);
			return pager.RenderHtml();
		}

		#endregion

		#region IQueryable<T> extensions

		public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize)
		{
			return new PagedList<T>(source, pageIndex, pageSize);
		}

		public static IPagedList<T> ToPagedList<T>(this IQueryable<T> source, int pageIndex, int pageSize, int totalCount)
		{
			return new PagedList<T>(source, pageIndex, pageSize, totalCount);
		}

		#endregion

		#region IEnumerable<T> extensions

		public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
		{
			return new PagedList<T>(source, pageIndex, pageSize);
		}

		public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
		{
			return new PagedList<T>(source, pageIndex, pageSize, totalCount);
		}

		#endregion
	}
}