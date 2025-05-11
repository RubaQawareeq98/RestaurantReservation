using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace RestaurantReservation.DB;

public class RestaurantReservationDbContextFactory : IDesignTimeDbContextFactory<RestaurantReservationDbContext>
{
    public RestaurantReservationDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../RestaurantReservation");

        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .Build();
        var optionsBuilder = new DbContextOptionsBuilder<RestaurantReservationDbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseSqlServer(connectionString);

        return new RestaurantReservationDbContext(optionsBuilder.Options);
    }
}