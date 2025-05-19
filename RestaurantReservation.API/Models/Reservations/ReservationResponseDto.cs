namespace RestaurantReservation.API.Models.Reservations;

public class ReservationResponseDto
{
    public int Id { get; set; }
    
    public DateTime ReservationDate { get; set; }
    
    public int PartySize { get; set; }
    
    public int? CustomerId { get; set; }
    
    public int? TableId { get; set; }
    
    public int RestaurantId { get; set; }
}
