namespace RestaurantReservation.DB.Models;

public class Order
{
    public int Id { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public int? ReservationId { get; set; }
    
    public Reservation? Reservation { get; set; }
    
    public int? EmployeeId { get; set; }
    
    public Employee? Employee { get; set; }
    
    public List<OrderItem> OrderItems { get; set; } = [];
    
    public PaymentDetail PaymentDetail { get; set; }

    public override string ToString()
    {
        return $"Order Id: {Id}, OrderDate: {OrderDate}, ReservationId: {ReservationId}, EmployeeId: {EmployeeId}, PaymentDetail: {PaymentDetail}";
    }
}
