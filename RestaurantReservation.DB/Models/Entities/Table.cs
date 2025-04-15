using RestaurantReservation.DB.Models.Interfaces;

namespace RestaurantReservation.DB.Models.Entities;

public class Table : IEntity
{
    public int Id { get; set; }
    
    public int Capacity { get; set; }
    
    public int? RestaurantId { get; set; }
    
    public Restaurant? Restaurant { get; set; }
    
    public List<Reservation> Reservations { get; set; } = [];
}
