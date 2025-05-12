using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public Task<List<Employee>> GetManagersAsync();
    public Task<decimal> CalculateAverageOrderAmount(int employeeId);
}