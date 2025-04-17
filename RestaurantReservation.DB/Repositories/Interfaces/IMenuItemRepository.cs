using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IMenuItemRepository : IBaseRepository<MenuItem>
{
    Task<List<MenuItem>> ListOrderedMenuItems(int reservationId);
}