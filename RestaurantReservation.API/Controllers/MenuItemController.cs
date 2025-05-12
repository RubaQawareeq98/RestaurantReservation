using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.MenuItems;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[ApiVersion("1.0")]
[Route("api/menuItems")]
[Authorize]
[ApiController]
public class MenuItemItemController(IMenuItemRepository menuItemRepository, IMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read MenuItems data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<MenuItem>>> GetMenuItems(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await menuItemRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<MenuItemResponseDto>>(data));
    }
    
    /// <summary>
    /// Get Menu Item by menu item id
    /// </summary>
    /// <param name="menuItemId"></param>
    /// <returns></returns>
    [HttpGet("{menuItemId:int}", Name ="GetMenuItemById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<MenuItem>> GetMenuItem(int menuItemId)
    {
        var menuItem = await menuItemRepository.GetByIdAsync(menuItemId);
        if (menuItem is null)
        {
            return NotFound("No menuItem found");
        }

        return Ok(mapper.Map<MenuItemResponseDto>(menuItem));
    }

    /// <summary>
    /// Create new menuItem
    /// </summary>
    /// <param name="menuItemRequest"></param>
    /// <returns>created menuItem</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<MenuItemResponseDto>> AddMenuItem(MenuItemRequestBodyDto menuItemRequest)
    {
        var menuItem = mapper.Map<MenuItem>(menuItemRequest);
        
        await menuItemRepository.AddAsync(menuItem);
        
        return CreatedAtRoute("GetMenuItemById", 
            new { menuItemId = menuItem.Id },
            mapper.Map<MenuItemResponseDto>(menuItem));
    }
    
    /// <summary>
    /// Update menuItem
    /// </summary>
    /// <param name="menuItemId"></param>
    /// <param name="menuItemRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{menuItemId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<MenuItemResponseDto>> UpdateMenuItem(int menuItemId,
        MenuItemRequestBodyDto menuItemRequestBody)
    {
        var menuItem = await menuItemRepository.GetByIdAsync(menuItemId);
        if (menuItem is null)
        {
            return NotFound("No menuItem found");
        }
        mapper.Map(menuItemRequestBody, menuItem);
        await menuItemRepository.UpdateAsync(menuItem);
        return NoContent();
    }
    
    /// <summary>
    /// Delete menuItem by id
    /// </summary>
    /// <param name="menuItemId"></param>
    /// <returns></returns>
    [HttpDelete("{menuItemId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<MenuItemResponseDto>> DeleteMenuItem(int menuItemId)
    {
        var menuItem = await menuItemRepository.GetByIdAsync(menuItemId);
        if (menuItem is null)
        {
            return NotFound("No menuItem found");
        }
        await menuItemRepository.DeleteAsync(menuItem);
        return NoContent();
    }
}
