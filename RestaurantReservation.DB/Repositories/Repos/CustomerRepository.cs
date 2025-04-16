using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Exceptions;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class CustomerRepository (RestaurantReservationDbContext context) : BaseRepository<Customer> (context), ICustomerRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public override async Task DeleteAsync(Customer entity)
    {
        var isExist = await IsEntityExist(entity.Id);
        if (!isExist)
        {
            throw new NoRecordFoundException();
        }
        
        var customer = await _context.Customers
            .Include(c => c.Reservations)
            .FirstAsync(c => c.Id == entity.Id);

        foreach (var reservation in customer.Reservations)
        {
            reservation.CustomerId = null;
        }
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
    }
}
