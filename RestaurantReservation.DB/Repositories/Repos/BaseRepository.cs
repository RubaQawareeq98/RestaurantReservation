using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Exceptions;
using RestaurantReservation.DB.Models.Interfaces;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class BaseRepository<T>(RestaurantReservationDbContext context) : IBaseRepository <T> where T : class, IEntity
{
    private readonly DbSet<T> _entitySet = context.Set<T>();
    
    public async Task AddAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        await _entitySet.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        var isExist = await IsEntityExist(entity.Id);
        if (!isExist)
        {
            throw new NoRecordFoundException();
        }
        _entitySet.Remove(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        ArgumentNullException.ThrowIfNull(entity);
        
        var isExist = await IsEntityExist(entity.Id);
        if (!isExist)
        {
            throw new NoRecordFoundException();
        }
        
        _entitySet.Update(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task<List<T>> GetAllAsync()
    {
        var data = await _entitySet.ToListAsync();
        return data;
    }

    public async Task<bool> IsEntityExist(int id)
    {
        return await _entitySet.AnyAsync(e => e.Id == id);
    }
}
