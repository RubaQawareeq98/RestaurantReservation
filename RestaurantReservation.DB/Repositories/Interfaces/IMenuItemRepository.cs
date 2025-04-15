using RestaurantReservation.DB.Models;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IMenuItemRepository
{
    Task<List<MenuItem>> GetMenuItemsAsync();
    Task AddMenuItemAsync(MenuItem menuItem);
    Task DeleteMenuItemAsync(MenuItem menuItem);
    Task UpdateMenuItemAsync(MenuItem menuItem);
}
