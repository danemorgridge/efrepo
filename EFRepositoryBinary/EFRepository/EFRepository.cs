using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EFRepository
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

		public T Get(int id)
		{
			var idProp = ObjectSet.ElementType.GetProperty(string.Format("{0}Id", ObjectSet.ElementType.Name)) ??
						 ObjectSet.ElementType.GetProperty("Id");
			if (idProp != null)
			{
				ParameterExpression idParam = Expression.Parameter(typeof(T));
				ConstantExpression idValue = Expression.Constant(id, typeof(int));
				MemberExpression idMbr = Expression.Property(idParam, idProp);
				BinaryExpression idExpression = Expression.Equal(idMbr, idValue);

				Expression<Func<T, bool>> lambda1 =
				Expression.Lambda<Func<T, bool>>(
					idExpression,
					new ParameterExpression[] { idParam });

				var entity = ObjectSet.FirstOrDefault(lambda1);

				return entity;
			}

			return null;
		}

		public void Delete(int id)
		{
			var idProp = ObjectSet.ElementType.GetProperty(string.Format("{0}Id", ObjectSet.ElementType.Name)) ??
						 ObjectSet.ElementType.GetProperty("Id");
			if (idProp != null)
			{
				ParameterExpression idParam = Expression.Parameter(typeof(T));
				ConstantExpression idValue = Expression.Constant(id, typeof(int));
				MemberExpression idMbr = Expression.Property(idParam, idProp);
				BinaryExpression idExpression = Expression.Equal(idMbr, idValue);

				Expression<Func<T, bool>> lambda1 =
				Expression.Lambda<Func<T, bool>>(
					idExpression,
					new ParameterExpression[] { idParam });

				var entity = ObjectSet.FirstOrDefault(lambda1);

				if (entity != null)
				{
					ObjectSet.Remove(entity);
				}
			}
		}

		public void Delete(T entity)
		{
			ObjectSet.Remove(entity);
		}

	}
}