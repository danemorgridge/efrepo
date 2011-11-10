using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC3ObjectContext_StructureMap.Data;
using MVC3ObjectContext_StructureMap.Web.Controllers;
using StructureMap;

namespace MVC3ObjectContext_StructureMap.Web
{
	public class StructureMapContainerSetup
	{
		public static void SetUp()
		{

			IContainer container = new Container(
							x =>
							{
								x.For<IPersonRepository>().
								     Use<PersonRepository>();
								x.For<IUnitOfWork>().
										 Use<EFUnitOfWork>();
							});
			DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
		}

	}
}