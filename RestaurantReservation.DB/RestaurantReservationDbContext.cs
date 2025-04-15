using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models;
using RestaurantReservation.DB.Seeds;

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
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
                "Data Source = lenovo\\SQLEXPRESS01; Initial Catalog = RestaurantReservationCore; Integrated Security = True; Encrypt = false")
            // .LogTo(Console.WriteLine);
            ;
    }

    private static void OnDeleteConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Table)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TableId)
            .OnDelete(DeleteBehavior.Restrict); 
        
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Restaurant)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.RestaurantId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Employee)
            .WithMany(e => e.Orders)
            .HasForeignKey(o => o.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
        
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Reservation)
            .WithMany(r => r.Orders)
            .HasForeignKey(o => o.ReservationId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PaymentDetail>()
            .HasKey(p => p.OrderId);
    }


    private static void SeedEntities(ModelBuilder modelBuilder)
    {
        var restaurants = EntitiesSeed.SeedRestaurants();
        var tables = EntitiesSeed.SeedTables();
        var orders = EntitiesSeed.SeedOrders();
        var paymentDetails = EntitiesSeed.SeedPaymentDetails();
        var orderItems = EntitiesSeed.SeedOrderItems();
        var menuItems = EntitiesSeed.SeedMenuItems();
        var customers = EntitiesSeed.SeedCustomers();
        var employees = EntitiesSeed.SeedEmployees();
        var reservations = EntitiesSeed.SeedReservations();
        var positions = EntitiesSeed.SeedPositions();
        var openingHours = EntitiesSeed.SeedOpeningHours();
        
        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<Restaurant>().HasData(restaurants);
        modelBuilder.Entity<Table>().HasData(tables);
        modelBuilder.Entity<Position>().HasData(positions);
        modelBuilder.Entity<OpeningHour>().HasData(openingHours);
        modelBuilder.Entity<Employee>().HasData(employees);
        modelBuilder.Entity<Reservation>().HasData(reservations);
        modelBuilder.Entity<MenuItem>().HasData(menuItems);
        modelBuilder.Entity<OrderItem>().HasData(orderItems);
        modelBuilder.Entity<Order>().HasData(orders);
        modelBuilder.Entity<PaymentDetail>().HasData(paymentDetails);
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        OnDeleteConfiguration(modelBuilder);
        SeedEntities(modelBuilder);
        
         
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<string>().HaveMaxLength(100);
    }
}
