using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[Route("api/restaurants")]
[ApiController]
public class RestaurantController(IRestaurantRepository restaurantRepository, IMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    [HttpGet]
    public async Task<ActionResult<List<Restaurant>>> GetRestaurants(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await restaurantRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<RestaurantResponseDto>>(data));
    }

    [HttpGet("{id}", Name ="GetRestaurantById")]
    public async Task<ActionResult<Restaurant>> GetRestaurant(int restaurantId)
    {
        var restaurant = await restaurantRepository.GetByIdAsync(restaurantId);
        if (restaurant is null)
        {
            return NotFound("No restaurant found");
        }

        return Ok(restaurant);
    }

    /// <summary>
    /// Create new Restaurant
    /// </summary>
    /// <param name="restaurantRequestBody"></param>
    /// <returns>created restaurant</returns>
    [HttpPost]
    public async Task<ActionResult<Restaurant>> AddRestaurant(RestaurantRequestBodyDto restaurantRequestBody)
    {
        var restaurant = mapper.Map<Restaurant>(restaurantRequestBody);
        
        await restaurantRepository.AddAsync(restaurant);
        
        return CreatedAtRoute("GetRestaurantById", 
            new { id = restaurant.Id },
            mapper.Map<RestaurantResponseDto>(restaurant));
    }
}