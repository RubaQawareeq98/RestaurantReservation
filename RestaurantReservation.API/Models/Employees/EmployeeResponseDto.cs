using RestaurantReservation.DB.Models.Enums;

namespace RestaurantReservation.API.Models.Employees;

public class EmployeeResponseDto
{
    public required int Id { get; set; }
    
    public required string FirstName { get; set; }
    
    public required string LastName { get; set; }
    
    public Position Position { get; set; }
    
    public int? RestaurantId { get; set; }
}