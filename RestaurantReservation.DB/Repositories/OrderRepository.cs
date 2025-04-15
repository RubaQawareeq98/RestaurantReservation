using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class OrderRepository (RestaurantReservationDbContext context) : IOrderRepository
{
    public async Task<List<Order>> GetOrdersAsync()
    {
        var orders = await context.Orders.ToListAsync();
        return orders;
    }

    public async Task AddOrderAsync(Order order)
    {
        context.Orders.Add(order);
        await context.SaveChangesAsync();
    }

    public async Task UpdateOrderAsync(Order order)
    {
        context.Orders.Update(order);
        await context.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(Order order)
    {
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
    }
}
