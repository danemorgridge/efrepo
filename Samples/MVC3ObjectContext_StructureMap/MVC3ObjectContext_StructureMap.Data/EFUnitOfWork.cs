using System.Data.Objects;

namespace MVC3ObjectContext_StructureMap.Data
{
	public class EFUnitOfWork : IUnitOfWork
	{
		public ObjectContext Context { get; set; }

		public EFUnitOfWork()
		{
			Context = new EFDemoEntities();
		}

		public void Commit()
		{
			Context.SaveChanges();
		}
		
		public bool LazyLoadingEnabled
		{
			get { return Context.ContextOptions.LazyLoadingEnabled; }
			set { Context.ContextOptions.LazyLoadingEnabled = value;}
		}

		public bool ProxyCreationEnabled
		{
			get { return Context.ContextOptions.ProxyCreationEnabled; }
			set { Context.ContextOptions.ProxyCreationEnabled = value; }
		}
		
		public string ConnectionString
		{
			get { return Context.Connection.ConnectionString; }
			set { Context.Connection.ConnectionString = value; }
		}
	}
}
