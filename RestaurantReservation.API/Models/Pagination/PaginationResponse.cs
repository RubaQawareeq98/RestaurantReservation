namespace RestaurantReservation.API.Models.Pagination;

public class PaginationResponse<T>(List<T> data, int totalItems, int pageNumber, int pageSize)
{
    public List<T> Data { get; set; } = data;
    public int TotalItems { get; set; } = data.Count;
    public int TotalPages { get; set; } = (int)Math.Ceiling(totalItems / (double)pageSize);
    public int PageNumber { get; set; } = pageNumber;
    public int PageSize { get; set; } = pageSize;
}
