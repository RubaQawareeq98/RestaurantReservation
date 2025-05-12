using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class MenuItemRepository(RestaurantReservationDbContext context)
    : BaseRepository<MenuItem>(context), IMenuItemRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public async Task<(List<MenuItem> data, PaginationResponse paginationResponse)> ListOrderedMenuItems(
        int reservationId, int pageNumber, int pageSize)
    {
        await EnsureEntityExist(reservationId);
        
        var items = _context.OrderItems
            .Where(o => o.Order.ReservationId == reservationId)
            .Select(o => o.MenuItem);
        
        var data = await items
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
        
        var paginationResponse = new PaginationResponse(data.Count, pageNumber, pageSize);

        return (data, paginationResponse);
    }
}
