using Microsoft.Data.Sqlite;
using RefactorThis.Infrastructure;
using RefactorThis.Infrastructure.Interfaces;
using RefactorThis.Models;
using RefactorThis.Services.Interfaces;

namespace RefactorThis.Services
{
	public class ProductOptionsService : BaseService, IProductOptionsService
	{
		private readonly IProductOptionRepository<ProductOption> _productOptionRepository;
		public ProductOptionsService(IProductOptionRepository<ProductOption> productOptionRepository)
		{
			_productOptionRepository = productOptionRepository;
		}

		/// <summary>
		/// Get Options
		/// </summary>
		/// <param name="productId"></param>
		/// <returns></returns>
		public List<ProductOption> GetList(Guid productId)
		{
			return	_productOptionRepository.GetList(productId);
		}

		/// <summary>
		/// Get product option
		/// </summary>
		/// <param name="id"></param>
		/// <param name="productId"></param>
		/// <returns></returns>
		public ProductOption GetById(Guid productId, Guid id)
		{
			return _productOptionRepository.GetById(productId, id);
		}

		/// <summary>
		/// Add Option
		/// </summary>
		/// <param name="productOption"></param>
		/// <returns></returns>
		public bool Add(ProductOption productOption)
		{
			try
			{
				_productOptionRepository.Add(productOption);
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Updte Option
		/// </summary>
		/// <param name="productOption"></param>
		/// <returns></returns>
		public bool Update(ProductOption productOption)
		{
			try
			{
				_productOptionRepository.Update(productOption);
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Delete Option
		/// </summary>
		/// <param name="productid"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Delete(Guid productid, Guid id)
		{
			try
			{
				_productOptionRepository.Delete(productid, id);
			}
			catch
			{
				return false;
			}

			return true;
		}
	}
}
