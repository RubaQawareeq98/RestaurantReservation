using RestaurantReservation.API.Services;
using RestaurantReservation.API.Services.Interfaces;
using RestaurantReservation.DB;
using RestaurantReservation.DB.Repositories.Interfaces;
using RestaurantReservation.DB.Repositories.Repos;

namespace RestaurantReservation.API.ServiceRegistration;

public static class AddServices
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddDbContext<RestaurantReservationDbContext>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IReservationRepository, ReservationRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        services.AddScoped<ITableRepository, TableRepository>();
        services.AddScoped<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}