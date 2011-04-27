using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DbContextSample.Data
{
	public class EFRepository<T> : IRepository<T> where T : class
	{
		public IUnitOfWork UnitOfWork { get; set; }
		
		private IDbSet<T> _objectset;
		private IDbSet<T> ObjectSet
		{
			get
			{
				if (_objectset == null)
				{
					_objectset = UnitOfWork.Context.Set<T>();
				}
				return _objectset;
			}
		}

		public virtual IQueryable<T> All()
		{
			return ObjectSet.AsQueryable();
		}

		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
		{
			return ObjectSet.Where(expression);
		}

		public void Add(T entity)
		{
			ObjectSet.Add(entity);
		}

		public void Delete(T entity)
		{
			ObjectSet.Remove(entity);
		}

	}
}