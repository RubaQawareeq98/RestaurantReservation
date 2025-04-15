using RestaurantReservation.DB.Models;

namespace RestaurantReservation.DB.Repositories.Interfaces;

public interface ITableRepository
{
    Task<List<Table>> GetTablesAsync();
    Task AddTableAsync(Table table);
    Task DeleteTableAsync(Table table);
    Task UpdateTableAsync(Table table);
}
