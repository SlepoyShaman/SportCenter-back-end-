namespace SportCenter.Models.ExchangeModels
{
    public class GetProductsModel
    {
        public int CategoryId { get; set; }
        public int CurrentPage { get; set; }
        public int ProductsOnPage { get; set; }
    }
}
