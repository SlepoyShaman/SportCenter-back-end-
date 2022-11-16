using SportCenter.Extentions;
using SportCenter.Models.DataModels;

namespace SportCenter.Models.Cart
{
    public class Cart
    {
        private readonly ISession _session;
        public Cart(ISession session)
        {
            _session = session;
        }

        public void AddToCart(Product product)
        {
            var cart = _session.GetCart<List<CartProduct>>();

            if (cart == null)
                cart = new List<CartProduct>() {
                    new CartProduct { Id = product.Id, Name = product.Name,
                                      Img = product.Img, Price = product.Price, Quantity = 1} };
            else if (cart.Any(p => p.Id == product.Id))
                cart.Find(p => p.Id == product.Id).Quantity += 1;
            else
                cart.Add(new CartProduct
                {
                    Id = product.Id,
                    Name = product.Name,
                    Img = product.Img,
                    Price = product.Price,
                    Quantity = 1
                });

            _session.SetCart(cart);
        }

        public void RemoveFromCart(int productId)
        {
            var cart = _session.GetCart<List<CartProduct>>();

            if (cart.Any(p => p.Id == productId))
            {
                var cartProduct = cart.Find(p => p.Id == productId);

                if (cartProduct.Quantity < 2)
                    cart.Remove(cartProduct);
                else
                    cart.Find(p => p.Id == productId).Quantity -= 1;

                _session.SetCart(cart);
            }
            else throw new Exception("В корзине нет такого товара");
        }

        public List<CartProduct> GetCart() => _session.GetCart<List<CartProduct>>();
    }
}
