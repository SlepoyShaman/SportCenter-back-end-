using SportCenter.Models.DataModels;
using SportCenter.Models.ExchangeModels;

namespace SportCenter.Converters
{
    public static class GetModelsConverter
    {
        public static Product ConvertProduct(GetNewProductModel model)
        => new Product()
            {
                Name = model.Name,
                Price = model.Price,
                CategoryId = model.CategoryId,
                Img = model.Img.FileName
            };
        
    }
}
