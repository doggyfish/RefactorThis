using RefactorThis.Models;

namespace RefactorThis.Services.Interfaces
{
	public interface IProductOptionsService
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		List<ProductOption> GetList(Guid productId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="productId"></param>
		/// <returns></returns>
		ProductOption GetById(Guid id, Guid productId);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="productOption"></param>
		/// <returns></returns>
		bool Add(ProductOption productOption);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="productOption"></param>
		/// <returns></returns>
		bool Update(ProductOption productOption);

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		bool Delete(Guid productid, Guid id);
	}
}
