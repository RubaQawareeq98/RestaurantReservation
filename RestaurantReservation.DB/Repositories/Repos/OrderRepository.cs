using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class OrderRepository(RestaurantReservationDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public async Task<List<Order>> ListOrdersAndMenuItems(int reservationId)
    {
        await EnsureEntityExist(reservationId);

        return await _context.Orders
            .Where(o => o.ReservationId == reservationId)
            .Include(o => o.PaymentDetail)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.MenuItem)
            .ToListAsync();
    }

    public override async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders
                    .Include(o => o.PaymentDetail)
                    .ToListAsync();
    }
}
