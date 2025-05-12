using RestaurantReservation.API.Models.MenuItems;

namespace RestaurantReservation.API.Models.OrderWithMenuItems;

public class OrderWithMenuItemResponseDto
{
    public int OrderId { get; init; }
    public DateTime OrderDate { get; init; }
    public int Quantity { get; init; }
    public MenuItemResponseDto MenuItem { get; init; }
}
