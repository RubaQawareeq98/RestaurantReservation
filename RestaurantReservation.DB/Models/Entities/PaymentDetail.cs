using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Enums;

namespace RestaurantReservation.DB.Models.Entities;

public class PaymentDetail
{
    public int PaymentNumber { get; set; }
    
    public int OrderId { get; set; }
    
    public Order Order { get; set; }
    
    public DateTime PaymentDate { get; set; }
    
    [Precision(10, 2)]
    public decimal Amount { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }

    public override string ToString()
    {
        return $"orderId: {OrderId}, paymentDate: {PaymentDate}, amount: {Amount}, paymentMethod: {(PaymentMethod)}";
    }
}
