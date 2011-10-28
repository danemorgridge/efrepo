using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data.Entity;

namespace EFRepositoryTest
{
	public class ContactModel : DbContext
	{
		public ContactModel()
			: base("ContactDB")
		{
			
		}

		public DbSet<Person> People { get; set; }
		public DbSet<Address> Addresess { get; set; }

		
	}
}
