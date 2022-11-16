using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportCenter.Data;
using SportCenter.Converters;
using SportCenter.Models.DataModels;
using SportCenter.Models.ExchangeModels;

namespace SportCenter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly IRepository _repository;
        public ShopController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> GetProducts([FromBody]GetProductsModel model)
        {
            if (model.ProductsOnPage < 1 || model.CurrentPage < 1) return BadRequest();

            var result =  await _repository.GetAll<Product>().Where(p => p.CategoryId == model.CategoryId)
                .Skip(model.ProductsOnPage * (model.CurrentPage - 1)).Take(model.ProductsOnPage)
                .Select(p => ViewModelConverter.ConvertProduct(p)).ToArrayAsync();

            return Ok(result);
        }
    }
}
