using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MVC3ObjectContext_StructureMap.Data
{
	public partial class PersonRepository : EFRepository<Person>, IPersonRepository
	{
		public List<Person> GetPeople()
		{
			return this.All().ToList();
		}
	}

	public interface IPersonRepository : IRepository<Person>
	{
		List<Person> GetPeople();
	}
}