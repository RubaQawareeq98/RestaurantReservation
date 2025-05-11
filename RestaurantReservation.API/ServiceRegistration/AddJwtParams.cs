using RestaurantReservation.API.Configurations;

namespace RestaurantReservation.API.ServiceRegistration;

public static class AddJwtParams
{
    public static void RegisterJwtParams(this WebApplicationBuilder builder)
    {
        var jwtConfig = builder.Configuration
            .GetSection("Authentication")
            .Get<JwtConfiguration>();
        
        ArgumentNullException.ThrowIfNull(jwtConfig);

        builder.Services.AddSingleton(jwtConfig);
        builder.Services.RegisterAuthentication(jwtConfig);
    }
}
