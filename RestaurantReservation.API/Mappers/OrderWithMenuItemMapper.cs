using RestaurantReservation.API.Models.OrderWithMenuItems;
using RestaurantReservation.DB.DTOS;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class OrderWithMenuItemMapper
{
    public partial List<OrderWithMenuItemResponseDto> ToOrderWithMenuItemResponseDtoList(List<OrderWithMenuItem> orderWithMenuItems);
}