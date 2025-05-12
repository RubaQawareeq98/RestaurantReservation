using AutoMapper;
using RestaurantReservation.API.Models.Reservations;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        CreateMap<Reservation, ReservationResponseDto>();
        CreateMap<ReservationRequestDto, Reservation>();
    }
}