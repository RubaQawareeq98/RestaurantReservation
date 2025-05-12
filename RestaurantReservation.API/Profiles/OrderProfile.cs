using AutoMapper;
using RestaurantReservation.API.Models.Orders;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderResponseDto>();
        CreateMap<OrderRequestBodyDto, Order>();
    }
}
