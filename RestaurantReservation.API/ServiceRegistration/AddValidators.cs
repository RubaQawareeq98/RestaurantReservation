using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace RestaurantReservation.API.ServiceRegistration;

public static class AddValidators
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters();

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
