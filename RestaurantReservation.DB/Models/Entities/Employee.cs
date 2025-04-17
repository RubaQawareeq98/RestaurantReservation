using RestaurantReservation.DB.Models.Enums;
using RestaurantReservation.DB.Models.Interfaces;

namespace RestaurantReservation.DB.Models.Entities;

public class Employee : IEntity
{
    public int Id { get; set; }
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public Position Position { get; set; }
    
    public int? RestaurantId { get; set; }
    
    public Restaurant? Restaurant { get; set; }
    
    public List<Order> Orders { get; set; } = [];

    public override string ToString()
    {
        return $"Employee: {FirstName} {LastName} | {RestaurantId}";
    }
}
