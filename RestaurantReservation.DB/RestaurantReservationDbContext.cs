using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Configurations;
using RestaurantReservation.DB.Models;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Seeds;
using RestaurantReservation.DB.Views;

namespace RestaurantReservation.DB;

public class RestaurantReservationDbContext : DbContext 
{
    public DbSet<Customer> Customers { get; set; }
    
    public DbSet<Position> Positions { get; set; }
    
    public DbSet<Employee> Employees { get; set; }
    
    public DbSet<MenuItem> MenuItems { get; set; }
    
    public DbSet<OrderItem> OrderItems { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OpeningHour> OpeningHours { get; set; }
    
    public DbSet<Restaurant> Restaurants { get; set; }
    
    public DbSet<Table> Tables { get; set; }
    
    public DbSet<Reservation> Reservations { get; set; }
    
    public DbSet<PaymentDetail> PaymentDetails { get; set; }
    
    public DbSet<ReservationDetails> ReservationDetails { get; set; }
    
    public DbSet<EmployeeWithRestaurantDetails> EmployeeWithRestaurantDetails { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
                "Data Source = lenovo\\SQLEXPRESS01; Initial Catalog = RestaurantReservationCore; Integrated Security = True; Encrypt = false");
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureOnDelete();
        modelBuilder.Seed();
        modelBuilder.Entity<ReservationDetails>()
            .ToView("ReservationDetails")
            .HasNoKey();
        
        modelBuilder.Entity<EmployeeWithRestaurantDetails>()
            .ToView("EmployeeWithRestaurantDetails")
            .HasNoKey();

        modelBuilder.HasDbFunction(
            typeof(RestaurantReservationDbContext).GetMethod(nameof(CalculateTotalRevenue),
                [typeof(int)])!
        ).HasName("fn_CalculateTotalRevenue");
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(100);
    }

    [DbFunction("fn_CalculateTotalRevenue", "dbo")]
    public static decimal CalculateTotalRevenue(int restaurantId)
        => throw new NotImplementedException();
}
