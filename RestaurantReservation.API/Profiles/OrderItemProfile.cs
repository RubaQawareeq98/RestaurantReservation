using AutoMapper;
using RestaurantReservation.API.Models.OrderItems;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItem, OrderItemResponseDto>();
        CreateMap<OrderItemRequestBodyDto ,OrderItem>();
    }
}