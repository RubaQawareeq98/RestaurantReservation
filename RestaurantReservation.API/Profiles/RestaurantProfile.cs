using AutoMapper;
using RestaurantReservation.API.Models.Restaurants;
using RestaurantReservation.API.Models.Restaurants.OpeningHours;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<Restaurant, RestaurantResponseDto>();
        CreateMap<RestaurantRequestBodyDto, Restaurant>();
    }
}