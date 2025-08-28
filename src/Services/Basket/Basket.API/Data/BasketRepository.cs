
namespace Basket.API.Data
{
    public class BasketRepository : IBasketRepository
    {
  
        public Task<ShoppingCart> GetBasket(int userName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellation = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
