using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EFRepository
{ 
	public interface IRepository<T> 
	{
		IUnitOfWork UnitOfWork { get; set; }
		IQueryable<T> All();
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		void Add(T entity);
		void Delete(int id);
		T Get(int id);
		void Delete(T entity);
	}
}
