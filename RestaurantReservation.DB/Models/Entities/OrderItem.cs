namespace RestaurantReservation.DB.Models.Entities;

public class OrderItem : Entity
{
    public int Quantity { get; set; }
    
    public int? OrderId { get; set; }
    
    public Order Order { get; set; }
    
    public int MenuItemId { get; set; }
    
    public MenuItem MenuItem { get; set; }

    public override string ToString()
    {
        return $"""
                Id: {Id}, Quantity: {Quantity}, OrderId: {OrderId},
                MenuItem {MenuItem}
                """;
    }
}
