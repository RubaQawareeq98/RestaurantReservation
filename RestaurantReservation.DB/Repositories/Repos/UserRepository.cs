using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class UserRepository (RestaurantReservationDbContext context) : BaseRepository<User> (context), IUserRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public async Task<User?> GetUserAsync(string userName, string password)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == userName && u.Password == password);
        return user;
    }

    public async Task<User?> GetByUserNameAsync(string userName)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == userName);
        return user;
    }
}
