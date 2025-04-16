namespace RestaurantReservation.DB.Views;

public class EmployeeWithRestaurantDetails
{
    public int EmployeeId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int PositionId { get; set; }
    public int RestaurantId { get; set; }
    public string? RestaurantName { get; set; }
    public string? RestaurantAddress { get; set; }
    public string? RestaurantPhoneNumber { get; set; }
    public string Position { get; set; }
   
}
