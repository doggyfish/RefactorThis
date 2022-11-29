using Microsoft.AspNetCore.Mvc;
using RefactorThis.Models;
using RefactorThis.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RefactorThis.Controllers
{
	[Route("products")]
	[ApiController]
	public class ProductOptionsController : ControllerBase
	{
		IProductOptionsService _productOptionsService;
		public ProductOptionsController(IProductOptionsService productOptionsService)
		{
			_productOptionsService = productOptionsService;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet("{id}/options")]
		public ApiResult<ProductOption> GetOptions(Guid id)
		{
			return new ApiResult<ProductOption> { Items = _productOptionsService.GetList(id) };
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="optionId"></param>
		/// <returns></returns>
		[HttpGet("{id}/options/{optionId}")]
		public ProductOption Get(Guid id, Guid optionId)
		{
			return _productOptionsService.GetById(id, optionId);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="product"></param>
		[HttpPost("{id}/options")]
		public void Post(Guid id, [FromBody] ProductOption productOption)
		{
			productOption.ProductId = id;
			productOption.Id = Guid.NewGuid();
			_productOptionsService.Add(productOption);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="product"></param>
		[HttpPut("{id}/options/{optionId}")]
		public void Put(Guid id, Guid optionId, [FromBody] ProductOption productOption)
		{
			productOption.Id = optionId;
			productOption.ProductId = id;
			_productOptionsService.Update(productOption);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		[HttpDelete("{id}/options/{optionId}")]
		public void Delete(Guid id, Guid optionId)
		{
			_productOptionsService.Delete(id, optionId);
		}
	}
}
