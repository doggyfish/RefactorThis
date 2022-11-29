using System.Linq.Expressions;

namespace RefactorThis.Infrastructure.Interfaces
{
    public interface IRepository<T>
	{
		void Add(T entity);
		void Update(T entity);
	}
}
