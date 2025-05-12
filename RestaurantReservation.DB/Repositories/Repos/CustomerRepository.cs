using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class CustomerRepository(RestaurantReservationDbContext context)
    : BaseRepository<Customer>(context), ICustomerRepository;
