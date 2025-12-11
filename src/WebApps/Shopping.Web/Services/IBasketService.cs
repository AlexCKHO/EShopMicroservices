namespace Shopping.Web.Services;

public interface IBasketService
{
    [Get("/basket-service/basket/{userName}")]
    Task<GetBasketResponse> GetBasket(string userName);

    [Post("/basket-service/basket")]
    Task<StoreBasketResponse> StoreBasket(StoreBasketRequest request);

    [Delete("/basket-service/basket/{userName}")]
    Task<DeleteBasketResponse> DeleteBasket(string userName);

    [Post("/basket-service/basket/checkout")]
    Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request);
    
    public async Task<ShoppingCartModel> LoadUserBasket()
    {
        // Get Basket If Not Exist Create New Basket with Default Logged In User Name
        var userName = "swn";
        ShoppingCartModel basket;

        try
        {
            // NOTE: The GetBasket method is assumed to be part of the class or accessible via injection
            // The parameter 'basketService' was included in the signature but not used in the original image.
            // If GetBasket is an instance method, you might need an instance of a service.
            // Assuming GetBasket() is defined within the class or accessible via 'this'.
            var getBasketResponse = await GetBasket(userName);
            basket = getBasketResponse.Cart;
        }
        catch (Exception)
        {
            // Create a new default basket if retrieval fails (e.g., user not found, API down)
            basket = new ShoppingCartModel
            {
                UserName = userName,
                Items = []
            };
        }

        return basket;
    }
}