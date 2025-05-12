using RestaurantReservation.DB.Models.Enums;

namespace RestaurantReservation.API.Models.Orders.PaymentDetails;

public class PaymentDetailDto
{
    public int PaymentNumber { get; set; }
    
    public DateTime PaymentDate { get; set; }
    
    public decimal Amount { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
}
