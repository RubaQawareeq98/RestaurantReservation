using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles.Restaurants;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<Restaurant, RestaurantResponseDto>();
        CreateMap<RestaurantRequestBodyDto, Restaurant>();
    }
}