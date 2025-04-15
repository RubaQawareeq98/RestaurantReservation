using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<List<Order>> ListOrdersAndMenuItems(int reservationId);
}