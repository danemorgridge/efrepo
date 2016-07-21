using System;
using System.Data.Entity;

namespace EFRepository
{
	public interface IUnitOfWork : IDisposable
	{
		DbContext Context { get; set; }
		void Commit();
		bool LazyLoadingEnabled { get; set; }
	}
}