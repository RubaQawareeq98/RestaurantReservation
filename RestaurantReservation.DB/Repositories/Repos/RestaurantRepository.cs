using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class RestaurantRepository(RestaurantReservationDbContext context)
    : BaseRepository<Restaurant>(context), IRestaurantRepository;
