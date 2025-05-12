using RestaurantReservation.DB.Models.Enums;

namespace RestaurantReservation.API.Models.Authentication;

public class SignupRequestBodyDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}
