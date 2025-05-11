using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    public Task<(List<Employee> data, PaginationResponse paginationResponse)> GetManagersAsync(int pageNumber,
        int pageSize);
    public Task<decimal> CalculateAverageOrderAmount(int employeeId);
}