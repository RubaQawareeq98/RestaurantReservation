namespace RestaurantReservation.API.Models.OrderItems;

public class OrderItemResponseDto
{
    public int Id { get; set; }
    
    public int Quantity { get; set; }
    
    public int? OrderId { get; set; }
    
    public int MenuItemId { get; set; }
}
