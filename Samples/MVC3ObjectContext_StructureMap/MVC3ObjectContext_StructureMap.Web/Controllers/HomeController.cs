using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3ObjectContext_StructureMap.Data;

namespace MVC3ObjectContext_StructureMap.Web.Controllers
{
	public class HomeController : Controller
	{
		//
		// GET: /Home/

		IPersonRepository _personRepository { get; set; }
		IUnitOfWork _unitOfWork { get; set; }

		public HomeController()
		{
			
		}

		public HomeController(IPersonRepository personRepository, IUnitOfWork unitOfWork)
		{
			_personRepository = personRepository;
			_unitOfWork = unitOfWork;
			_personRepository.UnitOfWork = _unitOfWork;
		}

		public ActionResult Index()
		{
			var people = _personRepository.GetPeople();

			return View(people);
		}

	}
}
