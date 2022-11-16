namespace SportCenter.Models.ExchangeModels
{
    public class GetNewProductModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public IFormFile Img { get; set; }
    }
}
