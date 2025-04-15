using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Models;

public class PaymentDetail
{
    public int PaymentNumber { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
    public DateTime PaymentDate { get; set; }
    
    [Precision(10, 2)]
    public decimal Amount { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}
