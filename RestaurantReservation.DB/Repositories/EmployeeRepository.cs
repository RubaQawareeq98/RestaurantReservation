using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class EmployeeRepository (RestaurantReservationDbContext context) : IEmployeeRepository
{
    public async Task<List<Employee>> GetEmployeesAsync()
    {
        var employees = await context.Employees.ToListAsync();
        return employees;
    }

    public async Task AddEmployeeAsync(Employee employee)
    {
        context.Employees.Add(employee);
        await context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Employee employee)
    {
        context.Employees.Remove(employee);
        await context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        context.Employees.Update(employee);
        await context.SaveChangesAsync();
    }
}
