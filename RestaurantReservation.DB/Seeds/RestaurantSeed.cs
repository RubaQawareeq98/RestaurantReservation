using RestaurantReservation.DB.Models;

namespace RestaurantReservation.DB.Seeds;

public class ResturanSeed
{
    public static List<Restaurant> SeedRestaurants()
    {
        var restaurants = new List<Restaurant>
        {
            new() {Id = 1, Name = "Restaurant 1", Address = "Nablus", PhoneNumber = "256478912"},
            new() {Id = 2, Name = "Restaurant 2", Address = "Jenin", PhoneNumber = "256478459"},
            new() {Id = 3, Name = "Restaurant 3", Address = "Nablus", PhoneNumber = "123478912"},
            new() {Id = 4, Name = "Restaurant 4", Address = "Jericho", PhoneNumber = "785478912"},
            new() {Id = 5, Name = "Restaurant 5", Address = "Nablus", PhoneNumber = "587478912"}
        };
        return restaurants;
    }
}
