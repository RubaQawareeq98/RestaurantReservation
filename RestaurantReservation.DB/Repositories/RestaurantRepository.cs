using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class RestaurantRepository (RestaurantReservationDbContext context) : IRestaurantRepository
{
    public async Task<List<Restaurant>> GetAllRestaurantsAsync()
    {
        var restaurants = await context.Restaurants
            .Include(r => r.Reservations)
            .Include(r => r.OpeningHours)
            .ToListAsync();
        return restaurants;
    }

    public async Task AddRestaurantAsync(Restaurant restaurant)
    {
        await context.Restaurants.AddAsync(restaurant);
        await context.SaveChangesAsync();
    }

    public async Task DeleteRestaurantAsync(Restaurant restaurant)
    {
        context.Restaurants.Remove(restaurant);
        await context.SaveChangesAsync();
    }

    public async Task UpdateRestaurantAsync(Restaurant restaurant)
    {
        context.Restaurants.Update(restaurant);
        await context.SaveChangesAsync();
    }
}
