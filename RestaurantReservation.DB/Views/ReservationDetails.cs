namespace RestaurantReservation.DB.Views;

public class ReservationDetails
{
    public int Id { get; set; }
    public DateTime ReservationDate { get; set; }
    public int PartySize { get; set; }
    public int? TableId { get; set; }
    public int? CustomerId { get; set; }
    public string? CustomerFirstName { get; set; }
    public string? CustomerLastName { get; set; }
    public string? CustomerPhone { get; set; }
    public string? CustomerEmail { get; set; }
    public int RestaurantId { get; set; }
    public string? RestaurantName { get; set; }
    public string? RestaurantAddress { get; set; }
}
