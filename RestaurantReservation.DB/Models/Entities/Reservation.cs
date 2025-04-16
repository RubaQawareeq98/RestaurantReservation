using RestaurantReservation.DB.Models.Interfaces;

namespace RestaurantReservation.DB.Models.Entities;

public class Reservation : IEntity
{
    public int Id { get; set; }
    
    public DateTime ReservationDate { get; set; }
    
    public int PartySize { get; set; }
    
    public int? CustomerId { get; set; }
    
    public Customer? Customer { get; set; }
    
    public int? TableId { get; set; }
    
    public Table? Table { get; set; }
    
    public int RestaurantId { get; set; }
    
    public Restaurant? Restaurant { get; set; }
    
    public List<Order> Orders { get; set; } = [];

    public override string ToString()
    {
        return $"Id: {Id}, ReservationDate: {ReservationDate}, PartySize: {PartySize} Customer: {CustomerId}, Table: {TableId}, Restaurant: {RestaurantId}";
    }
}
