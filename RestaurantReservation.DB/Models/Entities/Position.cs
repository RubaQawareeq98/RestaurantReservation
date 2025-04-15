using RestaurantReservation.DB.Models.Interfaces;

namespace RestaurantReservation.DB.Models.Entities;

public class Position : IEntity
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public List<Employee> Employees { get; set; } = [];
}
