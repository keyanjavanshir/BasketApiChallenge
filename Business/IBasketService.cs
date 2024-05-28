using BasketApi.Models;

public interface IBasketService
{
    Task<Basket> CreateBasketAsync(string email);
    Task<Basket> GetBasketAsync(Guid basketId);
    // Task<Basket> AddOrderToBasketAsync(Guid basketId, int productId, int quantity);
    Task<Basket> UpdateBasketAsync(Basket basket);
}