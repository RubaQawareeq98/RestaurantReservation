namespace RestaurantReservation.API.Models.MenuItems;

public class MenuItemResponseDto
{
    public required int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    public decimal Price { get; set; }
    
    public int? RestaurantId { get; set; }
}
