namespace RestaurantReservation.DB.Models;

public class Restaurant
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public List<Employee> Employees { get; set; } = [];   
    public List<Table> Tables { get; set; } = [];
    public List<Reservation> Reservations { get; set; } = [];
    public List<MenuItem> MenuItems { get; set; } = [];
    public List<OpeningHour> OpeningHours { get; set; } = [];
}
