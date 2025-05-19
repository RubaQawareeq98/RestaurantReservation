namespace RestaurantReservation.API.Models.Tables;

public class TableResponseDto
{
    public int Id { get; set; }
    
    public int Capacity { get; set; }
    
    public int? RestaurantId { get; set; }
}
