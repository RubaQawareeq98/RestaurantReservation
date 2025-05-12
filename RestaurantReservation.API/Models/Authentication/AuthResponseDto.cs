namespace RestaurantReservation.API.Models.Authentication;

public class AuthResponseDto
{
    public string AccessToken { get; set; }
    public int ExpirationInMinuts { get; set; }
}
