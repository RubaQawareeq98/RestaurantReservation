using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Exceptions;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class MenuItemRepository(RestaurantReservationDbContext context)
    : BaseRepository<MenuItem>(context), IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public async Task<List<MenuItem>> ListOrderedMenuItems(int reservationId)
    {
        var isExist = await IsEntityExist(reservationId);
        if (!isExist)
        {
            throw new RecordNotFoundException();
        }
        
        return await _context.OrderItems
            .Where(o => o.Order.ReservationId == reservationId)
            .Select(o => o.MenuItem)
            .ToListAsync();
    }
}
