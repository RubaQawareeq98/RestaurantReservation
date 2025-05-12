using RestaurantReservation.DB.DTOS;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IOrderRepository : IBaseRepository<Order>
{
    Task<(List<OrderWithMenuItem> data, PaginationResponse paginationResponse)> ListOrdersAndMenuItems(
        int reservationId, int pageNumber, int pageSize);
}