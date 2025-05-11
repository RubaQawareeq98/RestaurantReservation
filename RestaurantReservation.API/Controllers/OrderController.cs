using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Orders;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[Route("api/orders")]
[ApiController]
public class OrderController(IOrderRepository orderRepository, IMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read Orders data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    
    [HttpGet]
    public async Task<ActionResult<List<Order>>> GetOrders(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await orderRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<OrderResponseDto>>(data));
    }

    [HttpGet("{orderId:int}", Name ="GetOrderById")]
    public async Task<ActionResult<Order>> GetOrder(int orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);
        if (order is null)
        {
            return NotFound("No order found");
        }

        return Ok(mapper.Map<OrderResponseDto>(order));
    }

    /// <summary>
    /// Create new order
    /// </summary>
    /// <param name="orderRequest"></param>
    /// <returns>created order</returns>
    [HttpPost]
    public async Task<ActionResult<OrderResponseDto>> AddOrder(OrderRequestBodyDto orderRequest)
    {
        var order = mapper.Map<Order>(orderRequest);
        
        await orderRepository.AddAsync(order);
        
        return CreatedAtRoute("GetOrderById", 
            new { orderId = order.Id },
            mapper.Map<OrderResponseDto>(order));
    }
    
    /// <summary>
    /// Update order
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="orderRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{orderId:int}")]
    public async Task<ActionResult<OrderResponseDto>> UpdateOrder(int orderId,
        OrderRequestBodyDto orderRequestBody)
    {
        var order = await orderRepository.GetByIdAsync(orderId);
        if (order is null)
        {
            return NotFound("No order found");
        }
        mapper.Map(orderRequestBody, order);
        await orderRepository.UpdateAsync(order);
        return NoContent();
    }
    
    /// <summary>
    /// Delete order by id
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    
    [HttpDelete("{orderId:int}")]
    public async Task<ActionResult<OrderResponseDto>> DeleteOrder(int orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);
        if (order is null)
        {
            return NotFound("No order found");
        }
        await orderRepository.DeleteAsync(order);
        return NoContent();
    }
}
