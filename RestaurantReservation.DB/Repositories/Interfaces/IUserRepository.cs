using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetByUserNameAsync(string userName, string password);
}