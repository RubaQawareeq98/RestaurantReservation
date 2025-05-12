using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantReservation.DB;

namespace RestaurantReservation.Configurations;

public static class HostBuilderConfiguration
{
    public static IServiceProvider Configure(this IHostBuilder hostBuilder)
    {
        var host = hostBuilder
            .ConfigureAppConfiguration((_, config) =>
            {
                config.AddJsonFile("./appsettings.json");
            })
            .ConfigureServices((context, services) =>
            {
                var connectionString = context.Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<RestaurantReservationDbContext>(options => options.UseSqlServer(connectionString));
                
                services.RegisterServices();
            })
            .Build();
        var scope = host.Services.CreateScope();
        return scope.ServiceProvider;
    }
}