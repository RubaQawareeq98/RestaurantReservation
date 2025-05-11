using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Authentication;
using RestaurantReservation.API.Services.Interfaces;

namespace RestaurantReservation.API.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController(IJwtTokenGeneratorService jwtTokenGeneratorService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] loginRequestBodyDto requestBody)
    {
        var accessToken = await jwtTokenGeneratorService.GenerateToken(requestBody.Username, requestBody.Password);
        if (accessToken is null)
        {
            return Unauthorized();
        }
        return Ok(new
        {
            accessToken
        });
    }
}
