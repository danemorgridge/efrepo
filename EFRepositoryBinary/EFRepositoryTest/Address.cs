using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace EFRepositoryTest
{
	public class Address
	{
		[Key]
		public int AddressId { get; set; }

		[MaxLength(50)]
		[Required]
		public string Street { get; set; }

		[MaxLength(50)]
		[Required]
		public string City { get; set; }

		[MaxLength(50)]
		[Required]
		public string State { get; set; }

		[MaxLength(50)]
		[Required]
		public string Zip { get; set; }

		[Required]
		public int PersonId { get; set; }
		
		public virtual Person Person { get; set; }
	}
}
