using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Mappers;
using RestaurantReservation.API.Models.Reservations;
using RestaurantReservation.DB.DTOS;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[ApiVersion("1.0")]
[Route("api/reservations")]
[Authorize]
[ApiController]
public class ReservationController(IReservationRepository reservationRepository,
    IOrderRepository orderRepository,
    IMenuItemRepository menuItemRepository,
    ReservationMapper reservationMapper,
    OrderWithMenuItemMapper orderWithMenuItemMapper,
    MenuItemMapper menuItemMapper) : ControllerBase
{
    private int _maxPageSize = 80;
    private const string Message = "Page number and page size must be greater than 0";
    private const string PaginationHeader = "X-Pagination-Metadata";

    /// <summary>
    /// Read Reservations data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Reservation>>> GetReservations(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest(Message);
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await reservationRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append(PaginationHeader, JsonSerializer.Serialize(paginationResponse));

        return Ok(reservationMapper.ToReservationResponseDtoList(data));
    }

    /// <summary>
    /// Get Reservation by reservation id
    /// </summary>
    /// <param name="reservationId"></param>
    /// <returns></returns>
    [HttpGet("{reservationId:int}", Name ="GetReservationById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Reservation>> GetReservation(int reservationId)
    {
        var reservation = await reservationRepository.GetByIdAsync(reservationId);
        if (reservation is null)
        {
            return NotFound("No Reservation found");
        }

        return Ok(reservationMapper.ToReservationResponseDto(reservation));
    }

    /// <summary>
    /// Create new Reservation
    /// </summary>
    /// <param name="reservationRequest"></param>
    /// <returns>created Reservation</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ReservationResponseDto>> AddReservation(ReservationRequestDto reservationRequest)
    {
        var reservation = reservationMapper.ToReservation(reservationRequest);
        
        await reservationRepository.AddAsync(reservation);
        
        return CreatedAtRoute("GetReservationById", 
            new { reservationId = reservation.Id },
            reservationMapper.ToReservationResponseDto(reservation));
    }
    
    /// <summary>
    /// Update Reservation
    /// </summary>
    /// <param name="reservationId"></param>
    /// <param name="reservationRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{reservationId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<ReservationResponseDto>> UpdateReservation(int reservationId,
        ReservationRequestDto reservationRequestBody)
    {
        var reservation = await reservationRepository.GetByIdAsync(reservationId);
        if (reservation is null)
        {
            return NotFound("No Reservation found");
        }
        reservation = reservationMapper.ToReservation(reservationRequestBody);
        await reservationRepository.UpdateAsync(reservation);
        return NoContent();
    }
    
    /// <summary>
    /// Delete Reservation by id
    /// </summary>
    /// <param name="reservationId"></param>
    /// <returns></returns>
    [HttpDelete("{reservationId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<ReservationResponseDto>> DeleteReservation(int reservationId)
    {
        var reservation = await reservationRepository.GetByIdAsync(reservationId);
        if (reservation is null)
        {
            return NotFound("No Reservation found");
        }
        await reservationRepository.DeleteAsync(reservation);
        return NoContent();
    }
    
    /// <summary>
    /// Retrieve reservations by customer ID.
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [HttpGet("customer/{customerId:int}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Reservation>>> GetReservationsByCustomerId(int pageNumber, int pageSize,
        int customerId)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest(Message);
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);

        var (reservations, paginationResponse) = await reservationRepository.GetReservationsByCustomer(customerId, pageNumber, pageSize);
        Response.Headers.Append(PaginationHeader, JsonSerializer.Serialize(paginationResponse));

        return Ok(reservationMapper.ToReservationResponseDtoList(reservations));
    }
    
    /// <summary>
    /// List orders and menu items for a reservation.
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="reservationId"></param>
    /// <returns></returns>
    [HttpGet("{reservationId:int}/orders")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OrderWithMenuItem>>> GetReservationOrders(int pageNumber, int pageSize,
        int reservationId)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest(Message);
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);

        var (orders, paginationResponse) = await orderRepository.ListOrdersAndMenuItems(reservationId, pageNumber, pageSize);
        Response.Headers.Append(PaginationHeader, JsonSerializer.Serialize(paginationResponse));

        return Ok(orderWithMenuItemMapper.ToOrderWithMenuItemResponseDtoList(orders));
    }
    
    /// <summary>
    /// List ordered menu items for a reservation.
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="reservationId"></param>
    /// <returns></returns>
    [HttpGet("{reservationId:int}/menu-items")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<OrderWithMenuItem>>> GetReservationMenuItems(int pageNumber, int pageSize,
        int reservationId)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest(Message);
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);

        var (items, paginationResponse) = await menuItemRepository.ListOrderedMenuItems(reservationId, pageNumber, pageSize);
        Response.Headers.Append(PaginationHeader, JsonSerializer.Serialize(paginationResponse));

        return Ok(menuItemMapper.ToMenuItemResponseDtoList(items));
    }
}
