using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IReservationRepository : IBaseRepository<Reservation>
{
    Task<List<Reservation>> GetReservationsByCustomer(int customerId);
}