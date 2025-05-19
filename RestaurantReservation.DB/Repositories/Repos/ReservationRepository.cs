using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class ReservationRepository(RestaurantReservationDbContext context)
    : BaseRepository<Reservation>(context), IReservationRepository
{
    private readonly RestaurantReservationDbContext _context = context;
    
    public async Task<(List<Reservation> data, PaginationResponse paginationResponse)> GetReservationsByCustomer(
        int customerId, int pageNumber, int pageSize)
    {
        var reservations =  await _context.Reservations
            .Where(r => r.CustomerId == customerId)
            .ToListAsync();
        
        var data = reservations
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        var paginationResponse = new PaginationResponse(reservations.Count, pageNumber, pageSize);

        return (data, paginationResponse);
    }
}
