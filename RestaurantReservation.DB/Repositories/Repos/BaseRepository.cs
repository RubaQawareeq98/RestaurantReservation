using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Exceptions;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class BaseRepository<T>(RestaurantReservationDbContext context) : IBaseRepository <T> where T : Entity
{
    private readonly DbSet<T> _entitySet = context.Set<T>();
    
    public async Task AddAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        await _entitySet.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        await EnsureEntityExist(entity.Id);
        _entitySet.Remove(entity);
        await context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(T? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await EnsureEntityExist(entity.Id);
        
        _entitySet.Update(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task<List<T>> GetAllAsync(int pageNumber, int pageSize)
    {
        var data = await _entitySet
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return data;
    }

    public async Task EnsureEntityExist(int id)
    {
        var isExist = await _entitySet.AnyAsync(e => e.Id == id);
        if (!isExist)
        {
            throw new RecordNotFoundException($"{typeof(T)} with id: {id} not found");
        }
    }
}
