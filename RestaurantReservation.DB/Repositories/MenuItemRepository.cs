using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class MenuItemRepository (RestaurantReservationDbContext context) : IMenuItemRepository
{
    public async Task<List<MenuItem>> GetMenuItemsAsync()
    {
        var menuItems = await context.MenuItems.ToListAsync();
        return menuItems;
    }

    public async Task AddMenuItemAsync(MenuItem menuItem)
    {
        await context.MenuItems.AddAsync(menuItem);
        await context.SaveChangesAsync();
    }

    public async Task DeleteMenuItemAsync(MenuItem menuItem)
    {
        context.MenuItems.Remove(menuItem);
        await context.SaveChangesAsync();
    }

    public async Task UpdateMenuItemAsync(MenuItem menuItem)
    {
        context.MenuItems.Update(menuItem);
        await context.SaveChangesAsync();
    }
}
