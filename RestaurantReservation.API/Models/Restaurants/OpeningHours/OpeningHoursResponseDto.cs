namespace RestaurantReservation.API.Models.Restaurants.OpeningHours;

public class OpeningHoursResponseDto
{
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeSpan OpenHour { get; set; }
    
    public TimeSpan CloseHour { get; set; }
}