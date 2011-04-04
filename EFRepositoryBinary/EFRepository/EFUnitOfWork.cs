using System.Data.Objects;
using System.Data.Entity;

namespace EFRepository
{
	public class EFUnitOfWork : IUnitOfWork
	{
		public DbContext Context { get; set; }

		public EFUnitOfWork()
		{
			//Context = new DataModel();
		}

		public void Commit()
		{
			Context.SaveChanges();
		}
		
		public bool LazyLoadingEnabled
		{
			get { return Context.Configuration.LazyLoadingEnabled; }
			set { Context.Configuration.LazyLoadingEnabled = value; }
		}

		public void Dispose()
		{
			Context.Dispose();
		}
		
		
	}
}
