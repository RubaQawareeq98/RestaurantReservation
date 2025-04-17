using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class TableRepository (RestaurantReservationDbContext context) : BaseRepository<Table> (context), ITableRepository ;