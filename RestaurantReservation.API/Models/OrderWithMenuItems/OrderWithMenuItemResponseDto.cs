using RestaurantReservation.API.Models.MenuItems;

namespace RestaurantReservation.API.Models.OrderWithMenuItems;

public class OrderWithMenuItemResponseDto
{
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public MenuItemResponseDto MenuItem { get; set; }
}
