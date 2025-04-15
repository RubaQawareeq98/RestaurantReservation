using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class ReservationRepository (RestaurantReservationDbContext context) : IReservationRepository
{
    public async Task<List<Reservation>> GetReservationsAsync()
    {
        var reservations = await context.Reservations.ToListAsync();
        return reservations;
    }

    public async Task AddReservationAsync(Reservation reservation)
    {
        context.Reservations.Add(reservation);
        await context.SaveChangesAsync();
    }

    public async Task DeleteReservationAsync(Reservation reservation)
    {
        context.Reservations.Remove(reservation);
        await context.SaveChangesAsync();
    }

    public async Task UpdateReservationAsync(Reservation reservation)
    {
        context.Reservations.Update(reservation);
        await context.SaveChangesAsync();
    }
}
