namespace RestaurantReservation.DB.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public int ReservationId { get; set; }
    public required Reservation Reservation { get; set; }
    public int EmployeeId { get; set; }
    public required Employee Employee { get; set; }
    public List<OrderItem> Items { get; set; } = [];
}
