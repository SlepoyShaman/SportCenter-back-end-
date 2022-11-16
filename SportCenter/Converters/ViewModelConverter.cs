using SportCenter.Models.DataModels;
using SportCenter.Models.ExchangeModels;

namespace SportCenter.Converters
{
    public static class ViewModelConverter
    {
        public static MembershipViewModel ConvertMembership(Membership membership, int DaysToBurn)
             => new MembershipViewModel()
             {
                 Id = membership.Id,
                 Name = membership.Name,
                 DaysToBurn = DaysToBurn,
                 IsPoolAvailable = membership.IsPoolAvailable,
                 IsSaunaAvailable = membership.IsSaunaAvailable
             };

        public static ProductViewModel ConvertProduct(Product product)
            => new ProductViewModel() 
            { 
                Id = product.Id, 
                Name = product.Name, 
                Img = product.Img, 
                Price = product.Price 
            };
    }
}
