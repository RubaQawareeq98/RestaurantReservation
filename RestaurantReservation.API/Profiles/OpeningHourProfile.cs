using AutoMapper;
using RestaurantReservation.API.Models.Restaurants.OpeningHours;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class OpeningHourProfile : Profile
{
    public OpeningHourProfile()
    {
        CreateMap<OpeningHour, OpeningHoursResponseDto>();
    }
}