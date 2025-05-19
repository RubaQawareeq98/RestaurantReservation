using RestaurantReservation.API.Models.Restaurants.OpeningHours;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class OpeningHourMapper
{
    public partial OpeningHoursResponseDto ToOpeningHoursResponseDto(OpeningHour openingHour);
}