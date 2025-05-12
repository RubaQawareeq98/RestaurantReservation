using RestaurantReservation.DB.DTOS;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<List<OrderWithMenuItem>> ListOrdersAndMenuItems(int reservationId);
}