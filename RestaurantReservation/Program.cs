using RestaurantReservation.DB;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;
using RestaurantReservation.DB.Repositories.Repos;

namespace RestaurantReservation;

static class Program
{
    private static RestaurantReservationDbContext _context = new RestaurantReservationDbContext();

    private static async Task TestCustomerCrudOperations()
    {
        ICustomerRepository customerRepository = new CustomerRepository( _context );
        var customer = new Customer { FirstName = "Eman", LastName = "Ahmad", Email = "emanahmad@gmail.com", PhoneNumber = "123456789" };
        await customerRepository.AddAsync(customer);
        
        customer.PhoneNumber = "059789456";
        await customerRepository.UpdateAsync(customer);

        var customers = await customerRepository.GetAllAsync();
        var deletedCustomer = customers.FirstOrDefault();
        await customerRepository.DeleteAsync(deletedCustomer);
        
        customers.ForEach(Console.WriteLine);
    }
    
    private static async Task TestEmployeeCrudOperations()
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository(_context);
        
        var employee = new Employee { FirstName = "Eman", LastName = "Ahmad", PositionId = 2, RestaurantId = 3};
        await employeeRepository.AddAsync(employee);

        employee.RestaurantId = 2;
        await employeeRepository.UpdateAsync(employee);

        var employees = await employeeRepository.GetAllAsync();
        var deletedEmployee = employees.FirstOrDefault();
        await employeeRepository.DeleteAsync(deletedEmployee);
        
        employees.ForEach(Console.WriteLine);
    }
 
    private static async Task TestRestaurantCrudOperations()
    {
        IRestaurantRepository restaurantRepository = new RestaurantRepository(_context);
        
        var restaurant = new Restaurant {Name = "Restaurant7", Address = "Nablus", PhoneNumber = "123456789"};
        await restaurantRepository.AddAsync(restaurant);

        restaurant.Name = "KFC";
        await restaurantRepository.UpdateAsync(restaurant);

        var restaurants = await restaurantRepository.GetAllAsync();
        var deletedRestaurant = restaurants.FirstOrDefault();
        await restaurantRepository.DeleteAsync(deletedRestaurant);
        
        restaurants.ForEach(Console.WriteLine);
    }

    static async Task Main()
    {
        //await TestCustomerCrudOperations();
        //await TestEmployeeCrudOperations();
        await TestRestaurantCrudOperations();
    }
}
