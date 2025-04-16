using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.DB.Configurations;

public static class ForeignKeyOnDeleteConfiguration
{
    public static void ConfigureOnDelete(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Table)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TableId)
            .OnDelete(DeleteBehavior.SetNull); 
        
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Restaurant)
            .WithMany(r => r.Reservations)
            .HasForeignKey(r => r.RestaurantId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Table>()
            .HasOne(t => t.Restaurant)
            .WithMany(r => r.Tables)
            .HasForeignKey(t => t.RestaurantId)
            .OnDelete(DeleteBehavior.SetNull);
            
        
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Reservation)
            .WithMany(r => r.Orders)
            .HasForeignKey(o => o.ReservationId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<Order>()
            .HasOne(o => o.Employee)
            .WithMany(e => e.Orders)
            .HasForeignKey(o => o.EmployeeId)
            .OnDelete(DeleteBehavior.SetNull);
        
        modelBuilder.Entity<OrderItem>()
            .HasOne(o => o.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.SetNull);
        
         modelBuilder.Entity<OrderItem>()
                    .HasOne(o => o.MenuItem)
                    .WithMany(m => m.OrderItems)
                    .HasForeignKey(o => o.MenuItemId)
                    .OnDelete(DeleteBehavior.SetNull);
         
         modelBuilder.Entity<MenuItem>()
             .HasOne(o => o.Restaurant)
             .WithMany(r => r.MenuItems)
             .HasForeignKey(o => o.RestaurantId)
             .OnDelete(DeleteBehavior.SetNull);
         
         modelBuilder.Entity<Employee>()
             .HasOne(e => e.Position)
             .WithMany(p => p.Employees)
             .HasForeignKey(e => e.PositionId)
             .OnDelete(DeleteBehavior.Restrict);
         
         modelBuilder.Entity<Employee>()
             .HasOne(e => e.Restaurant)
             .WithMany(r => r.Employees)
             .HasForeignKey(e => e.RestaurantId)
             .OnDelete(DeleteBehavior.SetNull);
         
         modelBuilder.Entity<OpeningHour>()
             .HasOne(o => o.Restaurant)
             .WithMany(r => r.OpeningHours)
             .HasForeignKey(o => o.RestaurantId)
             .OnDelete(DeleteBehavior.SetNull);
         
        modelBuilder.Entity<PaymentDetail>()
            .HasKey(p => p.OrderId);
    }
}
