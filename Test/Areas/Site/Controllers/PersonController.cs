using System.Web.Mvc;
using RepositoryLayer;
using Test.Areas.Site.Models;
using Test.Security.Attribute;

namespace Test.Areas.Site.Controllers
{
	[SqlInjection]
    public class PersonController : Controller
    {
	    private readonly PersonRepository _repository;
	    private const int Size = 200;

	    public PersonController()
	    {
		    _repository = new PersonRepository();
	    }


		[AcceptVerbs("GET")]
		public ActionResult Index(int? page, string search)
		{
			var index = page.HasValue ? page.Value - 1 : 0;
            
			var model = new ViewmodelPerson
			{
				CurrentPageID = index,
				SearchWord = search,
				Persons = string.IsNullOrEmpty(search)? _repository.GetAll(index, Size) : _repository.GetAllByPartialPhone(index, Size, search)
			};

            return View(model);
        }

		[AcceptVerbs("POST")]
		public ActionResult Index(int page, string search)
		{
			var model = new ViewmodelPerson
			{
				CurrentPageID = page,
				SearchWord = search,
				Persons = _repository.GetAllByPartialPhone(page, Size, search)
			};

			return View(model);
		}
    }
}