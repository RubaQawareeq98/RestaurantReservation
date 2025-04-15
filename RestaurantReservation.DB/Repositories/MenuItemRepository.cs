using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class MenuItemRepository(RestaurantReservationDbContext context)
    : BaseRepository<MenuItem>(context), IMenuItemRepository;
