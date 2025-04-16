using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Exceptions;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class TableRepository (RestaurantReservationDbContext context) : BaseRepository<Table> (context), ITableRepository 
{
    private readonly RestaurantReservationDbContext _context = context;

    public override async Task DeleteAsync(Table entity)
    {
        var isExist = await IsEntityExist(entity.Id);
        if (!isExist)
        {
            throw new NoRecordFoundException();
        }
        
        var table = await _context.Tables
            .Include(t => t.Reservations)
            .FirstAsync(t => t.Id == entity.Id);

        foreach (var reservation in table.Reservations)
        {
            reservation.TableId = null;
        }
        _context.Tables.Remove(table);
        await _context.SaveChangesAsync();
    }
}
