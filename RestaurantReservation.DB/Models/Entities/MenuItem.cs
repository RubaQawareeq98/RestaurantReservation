using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Interfaces;

namespace RestaurantReservation.DB.Models.Entities;

public class MenuItem : IEntity
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Description { get; set; }
    
    
    [Precision(10, 2)]
    public decimal Price { get; set; }
    
    public int? RestaurantId { get; set; }
    
    public Restaurant? Restaurant { get; set; }
    
    public List<OrderItem> OrderItems { get; set; } = [];

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Description: {Description}, Price: {Price}";
    }
}
