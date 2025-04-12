using Microsoft.EntityFrameworkCore;

namespace RestaurantReservation.DB;

public class RestaurantReservationDbContext : DbContext 
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source = lenovo\\SQLEXPRESS01; Initial Catalog = RestaurantReservationCore; Integrated Security = True; Encrypt = false");
    } 
}