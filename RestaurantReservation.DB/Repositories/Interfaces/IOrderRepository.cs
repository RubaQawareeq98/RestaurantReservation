using RestaurantReservation.DB.Models;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetOrdersAsync();
    Task AddOrderAsync(Order order);
    Task UpdateOrderAsync(Order order);
    Task DeleteOrderAsync(Order order);
}
