using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.API.Configurations;
using RestaurantReservation.API.Services.Interfaces;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Services;

public class JwtTokenGeneratorService(JwtConfiguration configuration, IUserRepository userRepository) : IJwtTokenGeneratorService
{
    public async Task<string?> GenerateToken(string? username, string? password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            return null;
        }
        var user = await userRepository.GetByUserNameAsync(username, password);
        if (user is null)
        {
            return null;
        }
        
        var securityKey = new SymmetricSecurityKey(
            Convert.FromBase64String(configuration.SecretKey));
            
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
        var claimsForToken = new List<Claim>
        {
            new("sub", user.Id.ToString()),
            new("userName", user.Username),
            new("role", user.Role.ToString()),
        };

        var jwt = new JwtSecurityToken(
            configuration.Issuer,
            configuration.Audience,
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingCredentials
        );
        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(jwt);
            
        return token;
    }
}
