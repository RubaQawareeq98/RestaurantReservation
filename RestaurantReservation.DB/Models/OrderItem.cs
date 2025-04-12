namespace RestaurantReservation.DB.Models;

public class OrderItem
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int OrderId { get; set; }
    public required Order Order { get; set; }
    public int MenuItemId { get; set; }
    public required MenuItem MenuItem { get; set; }
}
