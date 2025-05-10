namespace RestaurantReservation.API.Models.Restaurants;

public class RestaurantResponseDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    
    public required string PhoneNumber { get; set; }
    
    public required string Address { get; set; }
}