using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EFRepository;

namespace EFRepositoryTest
{
	public class ContactUnitOfWork : EFUnitOfWork
	{
		public ContactUnitOfWork()
		{
			Context = new ContactModel();
		}
	}
}
