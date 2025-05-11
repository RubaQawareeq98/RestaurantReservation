using RestaurantReservation.API.Models.Orders.PaymentDetails;

namespace RestaurantReservation.API.Models.Orders;

public class OrderResponseDto
{
    public int Id { get; set; }
    
    public DateTime OrderDate { get; set; }
    
    public int? ReservationId { get; set; }
    
    public int? EmployeeId { get; set; }
        
    public PaymentDetailDto PaymentDetail { get; set; }
}
