namespace RestaurantReservation.DB.Models;

public class MenuItem
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public int RestaurantId { get; set; }
    public required Restaurant Restaurant { get; set; }
    public List<OrderItem> OrderItems { get; set; } = [];
}
