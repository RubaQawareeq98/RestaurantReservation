namespace RestaurantReservation.DB.Models.Entities;

public class PaginationResponse(int totalItems, int pageNumber, int pageSize)
{
    public int TotalItems { get; set; } = totalItems;
    public int TotalPages { get; set; } = (int)Math.Ceiling(totalItems / (double)pageSize);
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
}
