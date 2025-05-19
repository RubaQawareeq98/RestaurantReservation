using RestaurantReservation.API.Models.Restaurants;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class RestaurantMapper
{
    public partial Restaurant ToRestaurant(RestaurantRequestBodyDto restaurantRequestBodyDto);
    public partial RestaurantResponseDto ToRestaurantResponseDto(Restaurant restaurant);
    public partial List<RestaurantResponseDto> ToRestaurantResponseDtoList(List<Restaurant> restaurants);
}