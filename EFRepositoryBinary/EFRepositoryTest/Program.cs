using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFRepositoryTest
{
	class Program
	{
		static void Main(string[] args)
		{
			using (ContactUnitOfWork unitOfWork = new ContactUnitOfWork())
			{
				PersonRepository repository = new PersonRepository();
				repository.UnitOfWork = unitOfWork;

				var people = repository.GetAllPeople();

				Console.WriteLine(people.Count);

			}
		}
	}
}
