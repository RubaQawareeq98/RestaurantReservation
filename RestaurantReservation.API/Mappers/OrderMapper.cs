using RestaurantReservation.API.Models.Orders;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class OrderMapper
{
    public partial Order ToOrder(OrderRequestBodyDto orderRequestBodyDto);
    public partial OrderResponseDto ToOrderResponseDto(Order order);
    public partial List<OrderResponseDto> ToOrderResponseDtoList(List<Order> orders);
}