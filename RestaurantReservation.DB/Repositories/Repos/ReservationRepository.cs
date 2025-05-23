using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class ReservationRepository(RestaurantReservationDbContext context)
    : BaseRepository<Reservation>(context), IReservationRepository
{
    private readonly RestaurantReservationDbContext _context = context;
    
    public async Task<List<Reservation>> GetReservationsByCustomer(int customerId)
    {
        return await _context.Reservations
            .Where(r => r.CustomerId == customerId)
            .ToListAsync();
    }
}
