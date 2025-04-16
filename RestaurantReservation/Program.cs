using RestaurantReservation.DB;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;
using RestaurantReservation.DB.Repositories.Repos;

namespace RestaurantReservation;

class Program
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

    static async Task Main(string[] args)
    {
        await TestCustomerCrudOperations();
    }
}
