using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class OrderItemRepository (RestaurantReservationDbContext context) : IOrderItemRepository
{
    public async Task<List<OrderItem>> GetAllItemsAsync()
    {
        var orderItems = await context.OrderItems.ToListAsync();
        return orderItems;
    }

    public async Task AddItemAsync(OrderItem item)
    {
        context.OrderItems.Add(item);
        await context.SaveChangesAsync();
    }

    public async Task DeleteItemAsync(OrderItem item)
    {
        context.OrderItems.Remove(item);
        await context.SaveChangesAsync();
    }

    public async Task UpdateItemAsync(OrderItem item)
    {
        context.OrderItems.Update(item);
        await context.SaveChangesAsync();
    }
}
