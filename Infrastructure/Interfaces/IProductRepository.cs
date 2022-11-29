namespace RefactorThis.Infrastructure.Interfaces
{
	public interface IProductRepository<T> : IRepository<T> 
	{
		T GetById(Guid id);
		List<T> GetList(string? filter);
		void Delete(Guid id);
	}
}
