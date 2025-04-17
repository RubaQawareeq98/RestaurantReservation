namespace RestaurantReservation.DB.Models.Entities;

public class Table : Entity
{
    public int Capacity { get; set; }
    
    public int? RestaurantId { get; set; }
    
    public Restaurant? Restaurant { get; set; }
    
    public List<Reservation> Reservations { get; set; } = [];
}
