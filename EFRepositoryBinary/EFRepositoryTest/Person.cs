using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace EFRepositoryTest
{
	public class Person
	{
		[Key]
		public int PersonId { get; set; }

		[StringLength(50)]
		[Required]
		public string FirstName { get; set; }

		[StringLength(50)]
		[Required]
		public string LastName { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		public virtual ICollection<Address> Addresses { get; set; }
	}
}
