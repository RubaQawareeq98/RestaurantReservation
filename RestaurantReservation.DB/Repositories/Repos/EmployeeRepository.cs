using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Exceptions;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class EmployeeRepository (RestaurantReservationDbContext context) : BaseRepository<Employee> (context), IEmployeeRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public override async Task DeleteAsync(Employee entity)
    {
        var isExist = await IsEntityExist(entity.Id);
        if (!isExist)
        {
            throw new NoRecordFoundException();
        }
        
        var employee = await _context.Employees
            .Include(e => e.Orders)
            .FirstAsync(e => e.Id == entity.Id);

        foreach (var order in employee.Orders)
        {
            order.EmployeeId = null;
        }
        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Employee>> GetManagersAsync()
    {
        return 
            await _context.Employees
                .Where(e => e.PositionId == 1)
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
