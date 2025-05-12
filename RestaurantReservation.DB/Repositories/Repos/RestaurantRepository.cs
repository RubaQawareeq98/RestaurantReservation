using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class RestaurantRepository(RestaurantReservationDbContext context)
    : BaseRepository<Restaurant>(context), IRestaurantRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public override async Task<(List<Restaurant> data, PaginationResponse paginationResponse)> GetAllAsync(int pageNumber, int pageSize)
    {
        var list = await _context.Restaurants
            .Join(_context.OpeningHours,
                r => r.Id,
                o => o.RestaurantId,
                (r, o) => new Restaurant
                {
                    Id = r.Id ,
                    Name = r.Name,
                    PhoneNumber = r.PhoneNumber,
                    Address = r.Address,
                    OpeningHours = new List<OpeningHour>{o},
                })
            .ToListAsync();
            
        
        var data = list
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        var paginationResponse = new PaginationResponse(list.Count, pageNumber, pageSize);

        return (data, paginationResponse);
    }
}
