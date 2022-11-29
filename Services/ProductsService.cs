using RefactorThis.Infrastructure.Interfaces;
using RefactorThis.Models;
using RefactorThis.Services.Interfaces;

namespace RefactorThis.Services
{
	public class ProductsService : BaseService, IProductsService
	{
		private readonly IProductRepository<Product> _productRepository;
		public ProductsService(IProductRepository<Product> productRepository)
		{
			_productRepository = productRepository;
		}

		/// <summary>
		/// Get a list of products
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public List<Product> GetList(string? name = "")
		{
			return _productRepository.GetList(name);
		}

		/// <summary>
		/// Get product detail
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Product GetById(Guid id)
		{
			return _productRepository.GetById(id);
		}

		/// <summary>
		/// Add product
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		public bool Add(Product product)
		{
			try
			{
				_productRepository.Add(product);
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// Update product
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
		public bool Update(Product product)
		{
			try
			{
				_productRepository.Update(product);
			}
			catch
			{
				return false;
			}

			return true;
		}

		/// <summary>
		/// deletes product and it's options.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool Delete(Guid id)
		{
			try
			{
				_productRepository.Delete(id);
			}
			catch
			{
				return false;
			}

			return true;
		}


	}
}
