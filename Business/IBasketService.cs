using BasketApi.Models;

public interface IBasketService
{
    Task<Basket> CreateBasketAsync(string email);
    Task<Basket> GetBasketAsync(Guid basketId);
    Task<Basket> UpdateBasketAsync(Basket basket);

    // Task<Basket> AddItemToBasketAsync(Guid basketId, int productId, int quantity);
    // Task<Basket> IncreaseProductQuantityInBasketAsync(Guid basketId, int productId, int quantity);
    // Task<Basket> DecreaseProductQuantityInBasketAsync(Guid basketId, int productId, int quantity);
    // Task<Basket> RemoveItemFromBasketAsync(Guid basketId, int productId);
    // Task<Basket> ClearBasketAsync(Guid basketId);
    // Task<Basket> SubmitBasketAsync(Guid basketId, string email);
}