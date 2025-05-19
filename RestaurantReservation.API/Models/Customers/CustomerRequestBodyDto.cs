namespace RestaurantReservation.API.Models.Customers;

public class CustomerRequestBodyDto
{
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public required string Email { get; set; }
    
    public required string PhoneNumber { get; set; }
}