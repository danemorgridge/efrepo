using System;
using System.Linq;
using System.Collections.Generic;
	
namespace DbContextSample.Data
{   
	public partial class PersonRepository : EFRepository<Person>
	{
		public List<Person> GetAllPeople()
		{
			return All().ToList();
		}
	}
}