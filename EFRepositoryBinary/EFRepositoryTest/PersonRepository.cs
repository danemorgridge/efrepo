using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFRepository;

namespace EFRepositoryTest
{
	public class PersonRepository : EFRepository<Person>
	{
		public List<Person> GetAllPeople()
		{
			return All().Include("Addresses").ToList();
		}
	}
}
