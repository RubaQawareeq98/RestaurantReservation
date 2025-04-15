using RestaurantReservation.DB.Models.Interfaces;

namespace RestaurantReservation.DB.Models.Entities;

public class Customer : IEntity
{
    public int Id { get; set; }
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string Email { get; set; }
    
    public required string PhoneNumber { get; set; }
    
    public List<Reservation> Reservations { get; set; } = [];

    public override string ToString()
    {
        return $"Customer: {FirstName} {LastName} | Email: {Email} | PhoneNumber: {PhoneNumber}";
    }
}
