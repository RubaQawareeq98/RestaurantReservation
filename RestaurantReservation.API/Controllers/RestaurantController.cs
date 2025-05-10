using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Pagination;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[Route("api/restaurants")]
[ApiController]
public class RestaurantController(IRestaurantRepository restaurantRepository) : ControllerBase
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
        
        var restaurants = await restaurantRepository.GetAllAsync(pageNumber, pageSize);
        
        var paginationResponse = new PaginationResponse<Restaurant>(restaurants, restaurants.Count, pageNumber, pageSize);
        
        return Ok(paginationResponse);
    }

    [HttpPost]
    public async Task<ActionResult<Restaurant>> AddRestaurant(Restaurant restaurant)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        await restaurantRepository.AddAsync(restaurant);
        return CreatedAtAction(nameof(GetRestaurants), new { id = restaurant.Id });
    }
}