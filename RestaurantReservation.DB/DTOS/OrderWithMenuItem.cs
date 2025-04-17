using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.DTOS;

public class OrderWithMenuItem
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public MenuItem MenuItem { get; set; }
    public override string ToString()
    {
        return $"Order: {OrderId}, OrderDate: {OrderDate}, Quantity: {Quantity}, MenuItem: {MenuItem}";
    }
}
