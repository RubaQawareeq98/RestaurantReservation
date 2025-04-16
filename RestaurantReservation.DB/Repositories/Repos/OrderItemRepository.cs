using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class OrderItemRepository(RestaurantReservationDbContext context)
    : BaseRepository<OrderItem>(context), IOrderItemRepository;
