using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IMenuItemRepository : IBaseRepository<MenuItem>
{
    Task<(List<MenuItem> data, PaginationResponse paginationResponse)> ListOrderedMenuItems(int reservationId,
        int pageNumber, int pageSize);
}