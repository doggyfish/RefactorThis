using Microsoft.AspNetCore.Mvc;
using RefactorThis.Models;
using RefactorThis.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RefactorThis.Controllers
{
	[Route("products")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		IProductsService _productsService;
		public ProductsController(IProductsService productsService)
		{
			_productsService = productsService;
		}

		/// <summary>
		/// Get products by name, and return all products if name is null or whitespace
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		[HttpGet]
		public ApiResult<Product> Get(string? name)
		{
			return new ApiResult<Product> { Items = _productsService.GetList(name) };
		}

		/// <summary>
		/// Get product by ID.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public Product Get(Guid id)
		{
			return _productsService.GetById(id);
		}

		/// <summary>
		/// Add product
		/// </summary>
		/// <param name="product"></param>
		[HttpPost]
		public void Post([FromBody] Product product)
		{
			product.Id = Guid.NewGuid();
			_productsService.Add(product);
		}

		/// <summary>
		/// update product
		/// </summary>
		/// <param name="id"></param>
		/// <param name="product"></param>
		[HttpPut("{id}")]
		public void Put(Guid id, [FromBody] Product product)
		{
			product.Id = id;
			_productsService.Update(product);
		}

		/// <summary>
		/// Delete product and it's options.
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("{id}")]
		public void Delete(Guid id)
		{
			_productsService.Delete(id);
		}
	}
}
