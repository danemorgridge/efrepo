using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Configuration.Properties.Primitive;
using System.Data.Entity.ModelConfiguration.Conventions.Configuration;
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

		protected override void OnModelCreating(System.Data.Entity.ModelConfiguration.ModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Add(new UnicodeAttributeConvention());
			base.OnModelCreating(modelBuilder);
		}
	}

	public class UnicodeAttribute : Attribute
	{
		bool _isUnicode;

		public UnicodeAttribute(bool isUnicode)
		{
			_isUnicode = isUnicode;
		}

		public bool IsUnicode { get { return _isUnicode; } }
	}

	public class UnicodeAttributeConvention : AttributeConfigurationConvention<PropertyInfo, StringPropertyConfiguration, UnicodeAttribute>
	{
		public override void Apply(PropertyInfo memberInfo, StringPropertyConfiguration configuration, UnicodeAttribute attribute)
		{
			configuration.IsUnicode = attribute.IsUnicode;
		}
	}
}
