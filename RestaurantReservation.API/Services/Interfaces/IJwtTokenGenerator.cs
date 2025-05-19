
namespace RestaurantReservation.API.Services.Interfaces;

public interface IJwtTokenGeneratorService
{
    Task<string?> GenerateToken(string? username, string? password);
}
