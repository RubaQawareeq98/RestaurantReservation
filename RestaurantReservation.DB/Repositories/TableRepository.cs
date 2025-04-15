using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories;

public class TableRepository (RestaurantReservationDbContext context) : ITableRepository
{
    public async Task<List<Table>> GetTablesAsync()
    {
        var tables = await context.Tables.ToListAsync();
        return tables;
    }

    public async Task AddTableAsync(Table table)
    {
        await context.Tables.AddAsync(table);
        await context.SaveChangesAsync();
    }

    public async Task DeleteTableAsync(Table table)
    {
        context.Tables.Remove(table);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTableAsync(Table table)
    {
        context.Tables.Update(table);
        await context.SaveChangesAsync();
    }
}
