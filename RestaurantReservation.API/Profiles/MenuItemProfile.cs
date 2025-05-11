using AutoMapper;
using RestaurantReservation.API.Models.MenuItems;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class MenuItemProfile : Profile
{
    public MenuItemProfile()
    {
        CreateMap<MenuItem, MenuItemResponseDto>();
        CreateMap<MenuItemRequestBodyDto, MenuItem>();
    }
}
