using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Models.Enums;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class EmployeeRepository (RestaurantReservationDbContext context) : BaseRepository<Employee> (context), IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context = context;
    
    public async Task<List<Employee>> GetManagersAsync()
    {
        return 
            await _context.Employees
                .Where(e => e.Position == Position.Manager)
                .ToListAsync();
    }

    public async Task<decimal> CalculateAverageOrderAmount(int employeeId)
    {
        return await _context.Orders
            .Where(e => e.EmployeeId == employeeId)
            .Select(o => o.PaymentDetail.Amount)
            .AverageAsync();
    }
}
