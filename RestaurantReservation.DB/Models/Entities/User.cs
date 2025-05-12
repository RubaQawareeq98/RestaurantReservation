using RestaurantReservation.DB.Models.Enums;

namespace RestaurantReservation.DB.Models.Entities;

public class User : Entity
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = String.Empty;
    public UserRole Role { get; set; }
}
