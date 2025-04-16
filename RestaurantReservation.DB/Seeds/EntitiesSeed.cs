using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Seeds;

public static class EntitiesSeed
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var restaurants = DataSeed.SeedRestaurants();
        var tables = DataSeed.SeedTables();
        var orders = DataSeed.SeedOrders();
        var paymentDetails = DataSeed.SeedPaymentDetails();
        var orderItems = DataSeed.SeedOrderItems();
        var menuItems = DataSeed.SeedMenuItems();
        var customers = DataSeed.SeedCustomers();
        var employees = DataSeed.SeedEmployees();
        var reservations = DataSeed.SeedReservations();
        var positions = DataSeed.SeedPositions();
        var openingHours = DataSeed.SeedOpeningHours();
        
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
}