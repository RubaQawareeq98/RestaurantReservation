using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.OrderItems;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[ApiVersion("1.0")]
[Route("api/orderItems")]
[Authorize]
[ApiController]
public class OrderItemItemController(IOrderItemRepository orderItemRepository, IMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read OrderItems data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    
    [HttpGet]
    public async Task<ActionResult<List<OrderItem>>> GetOrderItems(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await orderItemRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<OrderItemResponseDto>>(data));
    }

    [HttpGet("{orderItemId:int}", Name ="GetOrderItemById")]
    public async Task<ActionResult<OrderItem>> GetOrderItem(int orderItemId)
    {
        var orderItem = await orderItemRepository.GetByIdAsync(orderItemId);
        if (orderItem is null)
        {
            return NotFound("No orderItem found");
        }

        return Ok(mapper.Map<OrderItemResponseDto>(orderItem));
    }

    /// <summary>
    /// Create new orderItem
    /// </summary>
    /// <param name="orderItemRequest"></param>
    /// <returns>created orderItem</returns>
    [HttpPost]
    public async Task<ActionResult<OrderItemResponseDto>> AddOrderItem(OrderItemRequestBodyDto orderItemRequest)
    {
        var orderItem = mapper.Map<OrderItem>(orderItemRequest);
        
        await orderItemRepository.AddAsync(orderItem);
        
        return CreatedAtRoute("GetOrderItemById", 
            new { orderItemId = orderItem.Id },
            mapper.Map<OrderItemResponseDto>(orderItem));
    }
    
    /// <summary>
    /// Update orderItem
    /// </summary>
    /// <param name="orderItemId"></param>
    /// <param name="orderItemRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{orderItemId:int}")]
    public async Task<ActionResult<OrderItemResponseDto>> UpdateOrderItem(int orderItemId,
        OrderItemRequestBodyDto orderItemRequestBody)
    {
        var orderItem = await orderItemRepository.GetByIdAsync(orderItemId);
        if (orderItem is null)
        {
            return NotFound("No orderItem found");
        }
        mapper.Map(orderItemRequestBody, orderItem);
        await orderItemRepository.UpdateAsync(orderItem);
        return NoContent();
    }
    
    /// <summary>
    /// Delete orderItem by id
    /// </summary>
    /// <param name="orderItemId"></param>
    /// <returns></returns>
    
    [HttpDelete("{orderItemId:int}")]
    public async Task<ActionResult<OrderItemResponseDto>> DeleteOrderItem(int orderItemId)
    {
        var orderItem = await orderItemRepository.GetByIdAsync(orderItemId);
        if (orderItem is null)
        {
            return NotFound("No orderItem found");
        }
        await orderItemRepository.DeleteAsync(orderItem);
        return NoContent();
    }
}
