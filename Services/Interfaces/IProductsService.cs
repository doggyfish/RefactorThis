using RefactorThis.Models;

namespace RefactorThis.Services.Interfaces
{
	public interface IProductsService
	{
		List<Product> GetList(string? name = "");
		Product GetById(Guid id);
		bool Add(Product product);
		bool Update(Product product);
		bool Delete(Guid gId);
	}
}
