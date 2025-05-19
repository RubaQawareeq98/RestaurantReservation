using RestaurantReservation.API.Models.MenuItems;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class MenuItemMapper
{
    public partial MenuItem ToMenuItem(MenuItemRequestBodyDto menuItemRequestBodyDto);
    public partial MenuItemResponseDto ToMenuItemResponseDto(MenuItem menuItem);
    public partial List<MenuItemResponseDto> ToMenuItemResponseDtoList(List<MenuItem> menuItems);
}
