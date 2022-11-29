namespace RefactorThis.Infrastructure.Interfaces
{
	public interface IProductOptionRepository<T> : IRepository<T>
	{
		T GetById(Guid parentId, Guid id);
		List<T> GetList(Guid parentId);
		void Delete(Guid parentId, Guid id);
	}
}
