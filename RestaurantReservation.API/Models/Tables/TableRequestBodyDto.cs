namespace RestaurantReservation.API.Models.Tables;

public class TableRequestBodyDto
{
    public int Capacity { get; set; }
    
    public int? RestaurantId { get; set; }
}
