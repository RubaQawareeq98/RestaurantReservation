using RestaurantReservation.DB.Models;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IReservationRepository
{
    Task<List<Reservation>> GetReservationsAsync();
    Task AddReservationAsync(Reservation reservation);
    Task DeleteReservationAsync(Reservation reservation);
    Task UpdateReservationAsync(Reservation reservation);
}
