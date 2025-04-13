namespace RestaurantReservation.DB.Models;

public class Table
{
    public int Id { get; set; }
    public int Capacity { get; set; }
    public int RestaurantId { get; set; }
    public required Restaurant Restaurant { get; set; }
    public List<Reservation> Reservations { get; set; } = [];
}
