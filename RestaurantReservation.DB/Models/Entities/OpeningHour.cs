namespace RestaurantReservation.DB.Models.Entities;

public class OpeningHour : Entity
{
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeSpan OpenHour { get; set; }
    
    public TimeSpan CloseHour { get; set; }
    
    public int RestaurantId { get; set; }
    
    public Restaurant Restaurant { get; set; }
}
