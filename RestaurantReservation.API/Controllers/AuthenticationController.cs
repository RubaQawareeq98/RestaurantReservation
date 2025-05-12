using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Configurations;
using RestaurantReservation.API.Models.Authentication;
using RestaurantReservation.API.Services.Interfaces;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[ApiVersion("1.0")]
[Route("api/authentication")]
[ApiController]
public class AuthenticationController(IJwtTokenGeneratorService jwtTokenGeneratorService,
    IUserRepository userRepository,
    IMapper mapper,
    JwtConfiguration jwtConfiguration) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginRequestBodyDto requestBody)
    {
        var accessToken = await jwtTokenGeneratorService.GenerateToken(requestBody.Username, requestBody.Password);
        if (accessToken is null)
        {
            return Unauthorized();
        }
        
        var response = new AuthResponseDto
        {
            AccessToken = accessToken,
            ExpirationInMinuts = jwtConfiguration.TokenExpirationMinutes
        };
        return Ok(response);
    }
    
    [HttpPost("signup")]
    public async Task<ActionResult<string>> Signup([FromBody] SignupRequestBodyDto requestBody)
    {
        var user = await userRepository.GetByUserNameAsync(requestBody.Username);
        if (user is not null)
        {
            return BadRequest("User is already exist");
        }
        var newUser = mapper.Map<User>(requestBody);

        await userRepository.AddAsync(newUser);
        
        var accessToken = await jwtTokenGeneratorService.GenerateToken(requestBody.Username, requestBody.Password);
        
        var response = new AuthResponseDto
        {
            AccessToken = accessToken,
            ExpirationInMinuts = jwtConfiguration.TokenExpirationMinutes
        };
        return Ok(response);
    }
}
