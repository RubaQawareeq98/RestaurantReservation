using AutoMapper;
using RestaurantReservation.API.Models.Authentication;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class UserSignupProfile: Profile
{
    public UserSignupProfile()
    {
        CreateMap<SignupRequestBodyDto, User>();
    }
}
