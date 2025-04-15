using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Exceptions;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class ReservationRepository(RestaurantReservationDbContext context)
    : BaseRepository<Reservation>(context), IReservationRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public override async Task DeleteAsync(Reservation entity)
    {
        var isExist = await IsEntityExist(entity.Id);
        if (!isExist)
        {
            throw new NoRecordFoundException("Entity not found");
        }
        
        var reservation = await _context.Reservations
            .Include(r => r.Orders)
            .FirstAsync(r => r.Id == entity.Id);

        foreach (var order in reservation.Orders)
        {
            order.ReservationId = null;
        }
        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();
    }
}
