using RestaurantReservation.DB.Models.Interfaces;

namespace RestaurantReservation.DB.Models.Entities;

public class OpeningHour : IEntity
{
    public int Id { get; set; }
    
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeSpan OpenHour { get; set; }
    
    public TimeSpan CloseHour { get; set; }
    
    public int RestaurantId { get; set; }
    
    public Restaurant Restaurant { get; set; }
}
