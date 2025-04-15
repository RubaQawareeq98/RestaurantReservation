using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Exceptions;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class OrderRepository(RestaurantReservationDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public async Task<List<Order>> ListOrdersAndMenuItems(int reservationId)
    {
        var isExist = await IsEntityExist(reservationId);
        if (!isExist)
        {
            throw new NoRecordFoundException();
        }

        return await _context.Orders
            .Where(o => o.ReservationId == reservationId)
            .Include(o => o.PaymentDetail)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.MenuItem)
            .ToListAsync();
    }
}
