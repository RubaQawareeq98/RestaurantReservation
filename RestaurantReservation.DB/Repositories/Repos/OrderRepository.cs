using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB.DTOS;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.DB.Repositories.Repos;

public class OrderRepository(RestaurantReservationDbContext context) : BaseRepository<Order>(context), IOrderRepository
{
    private readonly RestaurantReservationDbContext _context = context;

    public async Task<List<OrderWithMenuItem>> ListOrdersAndMenuItems(int reservationId)
    {
        await EnsureEntityExist(reservationId);

        var list = await _context.Orders
            .Where(o => o.ReservationId == reservationId)
            .Join(_context.OrderItems,
                o => o.Id,
                oi => oi.OrderId,
                (o, oi) => new { o, oi })
            .Join(_context.MenuItems,
                temp => temp.oi.MenuItemId,
                m => m.Id,
                (temp, item) => new OrderWithMenuItem
                {
                    OrderId = temp.o.Id,
                    OrderDate = temp.o.OrderDate,
                    Quantity = temp.oi.Quantity,
                    MenuItem = new MenuItem
                    {
                        Id = temp.oi.MenuItemId,
                        Name = item.Name,
                        Price = item.Price,
                        Description = item.Description,
                    }
                })
            .ToListAsync();

        return list;
    }

    public override async Task<(List<Order> data, PaginationResponse paginationResponse)> GetAllAsync(int pageNumber,
        int pageSize)
    {
        var list = await _context.Orders
                    .Include(o => o.PaymentDetail)
                    .ToListAsync();
        
        var data = list
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToList();
        
        var paginationResponse = new PaginationResponse(list.Count, pageNumber, pageSize);

        return (data, paginationResponse);
    }
}
