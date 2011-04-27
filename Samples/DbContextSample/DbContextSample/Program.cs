using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbContextSample.Data;

namespace DbContextSample
{
	class Program
	{
		static void Main(string[] args)
		{

			EFUnitOfWork unitOfWork = new EFUnitOfWork();
			PersonRepository personRepository = new PersonRepository();
			personRepository.UnitOfWork = unitOfWork;

			var people = personRepository.GetAllPeople();

			foreach (var person in people)
			{
				Console.WriteLine("{0} {1} {2}", person.FirstName, person.LastName, person.DateOfBirth);
				foreach (var address in person.Addresses)
				{
					Console.WriteLine("{0} {1} {2} {3}", address.Street, address.City, address.State, address.Zip);
				}
			}

			Console.ReadLine();

		}
	}
}
