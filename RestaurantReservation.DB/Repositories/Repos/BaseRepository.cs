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

    public virtual async Task<(List<T> data, PaginationResponse paginationResponse)> GetAllAsync(int pageNumber,
        int pageSize)
    {
        var list = await _entitySet.ToListAsync();
        
        var data = list
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        var paginationResponse = new PaginationResponse(list.Count, pageNumber, pageSize);

        return (data, paginationResponse);
    }

    public async Task EnsureEntityExist(int id)
    {
        var isExist = await _entitySet.AnyAsync(e => e.Id == id);
        if (!isExist)
        {
            throw new RecordNotFoundException($"{typeof(T)} with id: {id} not found");
        }
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _entitySet.FirstOrDefaultAsync(e => e.Id == id);
    }
}
