using RestaurantReservation.DB.Models;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IOrderItemRepository
{
    Task<List<OrderItem>> GetAllItemsAsync();
    Task AddItemAsync(OrderItem item);
    Task DeleteItemAsync(OrderItem item);
    Task UpdateItemAsync(OrderItem item);
}
