using System;
using System.Threading.Tasks;
using BasketApi.Models;
using Microsoft.EntityFrameworkCore;

public class OrderLineService : IOrderLineService
{
    private readonly BasketContext _context;

    public OrderLineService(BasketContext context)
    {
        _context = context;
    }

    public async Task<OrderLine> AddOrderLineAsync(Guid basketId, OrderLine orderLine)
    {
        var basket = await _context.Baskets.Include(b => b.OrderLines).FirstOrDefaultAsync(b => b.Id == basketId);
        if (basket == null)
        {
            throw new Exception("Basket not found");
        }

        // Add the order line to the basket
        basket.OrderLines.Add(orderLine);

        // Update the total amount of the basket
        basket.totalAmount += orderLine.totalPrice;

        // Update the state of the basket entity
        _context.Entry(basket).State = EntityState.Modified;

        // Save changes to the database
        await _context.SaveChangesAsync();

        return orderLine;
    }
}