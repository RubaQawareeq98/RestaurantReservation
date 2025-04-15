using RestaurantReservation.DB.Models;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IRestaurantRepository
{
    Task<List<Restaurant>> GetAllRestaurantsAsync();
    Task AddRestaurantAsync(Restaurant restaurant);
    Task DeleteRestaurantAsync(Restaurant restaurant);
    Task UpdateRestaurantAsync(Restaurant restaurant);
}
