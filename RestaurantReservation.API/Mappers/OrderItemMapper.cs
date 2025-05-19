using RestaurantReservation.API.Models.OrderItems;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class OrderItemMapper
{
    public partial OrderItem ToOrderItem(OrderItemRequestBodyDto orderItemRequestBodyDto);
    public partial OrderItemResponseDto ToOrderItemResponseDto(OrderItem orderItem);
    public partial List<OrderItemResponseDto> ToOrderItemResponseDtoList(List<OrderItem> orderItems);
}