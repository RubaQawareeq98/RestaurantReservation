namespace RestaurantReservation.DB.Models;

public class Employee
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int PositionId { get; set; }
    public Position Position { get; set; }
    public int RestaurantId { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<Order> Orders { get; set; } = [];
}
