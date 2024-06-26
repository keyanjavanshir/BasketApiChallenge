using BasketApi.Models;
using Microsoft.EntityFrameworkCore;

public class BasketService : IBasketService
{
    private readonly BasketContext _context;

    public BasketService(BasketContext context)
    {
        _context = context;
    }

    public async Task<Basket> CreateBasketAsync(string email)
    {
        // Create a new basket
        var basket = new Basket
        {
            Id = Guid.NewGuid(),
            userEmail = email,
            totalAmount = 0
        };

        // Add the basket to the database
        _context.Baskets.Add(basket);
        await _context.SaveChangesAsync();

        return basket;
    }

    public async Task<Basket> GetBasketAsync(Guid basketId)
    {
        // Get the basket from the database using the basketId
        return await _context.Baskets.FirstOrDefaultAsync(b => b.Id == basketId);
    }

    public async Task<Basket> UpdateBasketAsync(Basket basket)
    {
        // Get the existing basket from the database
        var existingBasket = await _context.Baskets.Include(b => b.OrderLines).FirstOrDefaultAsync(b => b.Id == basket.Id);
        if (existingBasket == null)
        {
            throw new Exception("Basket not found");
        }

        // Update basket properties
        existingBasket.userEmail = basket.userEmail;
        existingBasket.totalAmount = basket.totalAmount;

        // Update the state of the basket entity
        _context.Entry(existingBasket).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return existingBasket;
    }
}