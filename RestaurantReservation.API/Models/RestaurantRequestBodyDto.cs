namespace RestaurantReservation.API.Models;

public class RestaurantRequestBodyDto
{
    public required string Name { get; set; }
    
    public required string PhoneNumber { get; set; }
    
    public required string Address { get; set; }
}