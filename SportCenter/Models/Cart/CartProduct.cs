using SportCenter.Models.DataModels;

namespace SportCenter.Models.Cart
{
    public class CartProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }
        public int Quantity { get; set; }
    }
}
