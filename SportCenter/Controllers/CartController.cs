using Microsoft.AspNetCore.Mvc;
using SportCenter.Data;
using SportCenter.Models.Cart;
using SportCenter.Models.DataModels;

namespace SportCenter.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IRepository _repository;
        public CartController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var product = await _repository.GetByIdAsync<Product>(productId);

            new Cart(HttpContext.Session).AddToCart(product);

            return Ok();
        }

        [HttpPost("Remove")]
        public IActionResult RemoveFromCart(int productId)
        {
            try
            {
                new Cart(HttpContext.Session).RemoveFromCart(productId);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            var products = new Cart(HttpContext.Session).GetCart();

            decimal sum = 0;
            foreach(var product in products)
                sum += product.Price * product.Quantity;

            return Ok(new { Products = products, Total = sum });
            

        }

        
    }
}
