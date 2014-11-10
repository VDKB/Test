using System.Collections.Generic;
using DomainClasses;
using Helpers;

namespace Test.Areas.Site.Models
{
	public class ViewmodelPerson
	{
		public IPagedList<Person> Persons { get; set; }
		public int CurrentPageID { get; set; }
		public string SearchWord { get; set; }
	}
}