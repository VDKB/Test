using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using DomainClasses;
using Helpers;
using PersonLayer;

namespace RepositoryLayer
{
    public class PersonRepository : IDisposable
    {

		private readonly PersonContext _context;

	    public PersonRepository()
	    {
		    _context = new PersonContext();
	    }

	    public IPagedList<Person> GetAll(int index, int page)
	    {
			return _context.Persons.OrderBy(f => f.City.Name).ToPagedList(index, page);
	    }

		public IPagedList<Person> GetAllByPartialPhone(int index, int page, string phone)
		{
			var search = string.Format("%{0}%", phone.Trim());
			return _context.Persons.Where(x => SqlFunctions.PatIndex(search, x.PhoneNumber) > 0).OrderBy(f => f.City.Name).ToPagedList(index, page);
		}


	    public void Dispose()
	    {
		    _context.Dispose();
	    }
    }
}
