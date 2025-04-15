using RestaurantReservation.DB.Models;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetEmployeesAsync();
    Task AddEmployeeAsync(Employee employee);
    Task DeleteEmployeeAsync(Employee employee);
    Task UpdateEmployeeAsync(Employee employee);
}
