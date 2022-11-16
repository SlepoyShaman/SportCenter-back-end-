using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportCenter.Converters;
using SportCenter.Data;
using SportCenter.Models.DataModels;
using SportCenter.Models.ExchangeModels;

namespace SportCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    public class AdminController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly string _imgDirectory;
        public AdminController(IRepository repository, IWebHostEnvironment appEnvirontment)
        {
            _repository = repository;
            _appEnvironment = appEnvirontment;
            _imgDirectory = appEnvirontment.WebRootPath + "/img/";
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm]GetNewProductModel model)
        {
            string path = "/img/" + model.Img.FileName;

            using(var fs = new FileStream(_imgDirectory + model.Img.FileName, FileMode.Create))
            {
                await model.Img.CopyToAsync(fs);
            }

            var product = GetModelsConverter.ConvertProduct(model);

            await _repository.AddAsync<Product>(product);

            return Ok();
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove([FromBody]int productId)
        {
            try
            {  
                var product = await _repository.RemoveByIdAsync<Product>(productId);

                string path = _appEnvironment.WebRootPath + "/img/" + product.Img;

                if(System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                return Ok();
            }
            catch
            {
                return BadRequest(new { Error = "Не удалось удалить данный элемент." });
            }
        }
    }

}
