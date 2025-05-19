using RestaurantReservation.API.Models.Authentication;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class UserSignupMapper
{
    public partial User ToUser(SignupRequestBodyDto signupRequestBodyDto);
}