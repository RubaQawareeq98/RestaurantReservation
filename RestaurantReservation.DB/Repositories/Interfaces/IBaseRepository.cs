namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface IBaseRepository <T>
{
    public Task AddAsync(T entity);
    public Task DeleteAsync(T? entity);
    public Task UpdateAsync(T? entity);
    public Task<List<T>> GetAllAsync(int pageNumber, int pageSize);
    public Task EnsureEntityExist(int id);
}
