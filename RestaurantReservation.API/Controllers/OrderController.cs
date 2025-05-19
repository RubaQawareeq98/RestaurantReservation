using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Mappers;
using RestaurantReservation.API.Models.Orders;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[ApiVersion("1.0")]
[Route("api/orders")]
[Authorize]
[ApiController]
public class OrderController(IOrderRepository orderRepository, OrderMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read Orders data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Order>>> GetOrders(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await orderRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.ToOrderResponseDtoList(data));
    }

    /// <summary>
    /// Get Order by order id
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    [HttpGet("{orderId:int}", Name ="GetOrderById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Order>> GetOrder(int orderId)
    {
        var order = await orderRepository.GetByIdAsync(orderId);
        if (order is null)
        {
            return NotFound("No order found");
        }

        return Ok(mapper.ToOrderResponseDto(order));
    }

    /// <summary>
    /// Create new order
    /// </summary>
    /// <param name="orderRequest"></param>
    /// <returns>created order</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<OrderResponseDto>> AddOrder(OrderRequestBodyDto orderRequest)
    {
        var order = mapper.ToOrder(orderRequest);
        
        await orderRepository.AddAsync(order);
        
        return CreatedAtRoute("GetOrderById", 
            new { orderId = order.Id },
            mapper.ToOrderResponseDto(order));
    }
    
    /// <summary>
    /// Update order
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="orderRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{orderId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<OrderResponseDto>> UpdateOrder(int orderId,
        OrderRequestBodyDto orderRequestBody)
    {
        var order = await orderRepository.GetByIdAsync(orderId);
        if (order is null)
        {
            return NotFound("No order found");
        }
        order.OrderDate = orderRequestBody.OrderDate;
        order.ReservationId = orderRequestBody.ReservationId;
        order.EmployeeId = orderRequestBody.EmployeeId;
        
        await orderRepository.UpdateAsync(order);
        return NoContent();
    }
    
    /// <summary>
    /// Delete order by id
    /// </summary>
    /// <param name="orderId"></param>
    /// <returns></returns>
    [HttpDelete("{orderId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
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
