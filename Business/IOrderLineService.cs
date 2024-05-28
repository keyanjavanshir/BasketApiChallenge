using BasketApi.Models;
public interface IOrderLineService
{
    Task<OrderLine> AddOrderLineAsync(Guid basketId, OrderLine orderLine);
}