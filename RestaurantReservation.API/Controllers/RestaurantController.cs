using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Mappers;
using RestaurantReservation.API.Models.Restaurants;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[ApiVersion("1.0")]
[Route("api/restaurants")]
[Authorize]
[ApiController]
public class RestaurantController(IRestaurantRepository restaurantRepository, RestaurantMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read Restaurants data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurants(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await restaurantRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.ToRestaurantResponseDtoList(data));
    }

    /// <summary>
    /// Get Restaurant by restaurant id
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <returns></returns>
    [HttpGet("{restaurantId:int}", Name ="GetRestaurantById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Restaurant>> GetRestaurant(int restaurantId)
    {
        var restaurant = await restaurantRepository.GetByIdAsync(restaurantId);
        if (restaurant is null)
        {
            return NotFound("No restaurant found");
        }

        return Ok(mapper.ToRestaurantResponseDto(restaurant));
    }

    /// <summary>
    /// Create new Restaurant
    /// </summary>
    /// <param name="restaurantRequestBody"></param>
    /// <returns>created restaurant</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<RestaurantResponseDto>> AddRestaurant(RestaurantRequestBodyDto restaurantRequestBody)
    {
        var restaurant = mapper.ToRestaurant(restaurantRequestBody);
        
        await restaurantRepository.AddAsync(restaurant);
        
        return CreatedAtRoute("GetRestaurantById", 
            new { id = restaurant.Id },
            mapper.ToRestaurantResponseDto(restaurant));
    }
    
    /// <summary>
    /// Update Restaurant
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <param name="restaurantRequestBody"></param>
    /// <returns></returns>

    [HttpPut("{restaurantId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RestaurantResponseDto>> UpdateRestaurant(int restaurantId,
        RestaurantRequestBodyDto restaurantRequestBody)
    {
        var restaurant = await restaurantRepository.GetByIdAsync(restaurantId);
        if (restaurant is null)
        {
            return NotFound("No restaurant found");
        }
        restaurant = mapper.ToRestaurant(restaurantRequestBody);
        await restaurantRepository.UpdateAsync(restaurant);
        return NoContent();
    }
    
    /// <summary>
    /// Delete restaurant by id
    /// </summary>
    /// <param name="restaurantId"></param>
    /// <returns></returns>

    [HttpDelete("{restaurantId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<RestaurantResponseDto>> DeleteRestaurant(int restaurantId)
    {
        var restaurant = await restaurantRepository.GetByIdAsync(restaurantId);
        if (restaurant is null)
        {
            return NotFound("No restaurant found");
        }
        await restaurantRepository.DeleteAsync(restaurant);
        return NoContent();
    }
}
