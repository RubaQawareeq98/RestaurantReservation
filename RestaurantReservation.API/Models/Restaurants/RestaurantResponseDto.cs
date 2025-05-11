using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Models.Restaurants;

public class RestaurantResponseDto
{
    public RestaurantResponseDto(List<OpeningHour> openingHours)
    {
        OpeningHours = openingHours;
    }

    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string PhoneNumber { get; set; }
    
    public required string Address { get; set; }
    
    public List<OpeningHour> OpeningHours { get; set; }
}