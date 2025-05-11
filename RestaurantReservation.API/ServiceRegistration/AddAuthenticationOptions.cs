using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.API.Configurations;

namespace RestaurantReservation.API.ServiceRegistration;

public static class AddAuthenticationOptions
{
    public static void RegisterAuthentication(this IServiceCollection services, JwtConfiguration jwtConfig)
    {
        services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfig.Issuer,
                    ValidAudience = jwtConfig.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Convert.FromBase64String(jwtConfig.SecretKey)
                    )
                };
            });
    }
}
