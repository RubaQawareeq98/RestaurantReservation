using AutoMapper;
using RestaurantReservation.API.Models.OrderWithMenuItems;
using RestaurantReservation.DB.DTOS;

namespace RestaurantReservation.API.Profiles;

public class OrderWithMenuItemsProfile : Profile
{
    public OrderWithMenuItemsProfile()
    {
        CreateMap<OrderWithMenuItem, OrderWithMenuItemResponseDto>();
    }
}
