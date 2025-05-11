using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Reservations;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[Route("api/reservations")]
[ApiController]
public class ReservationController(IReservationRepository reservationRepository, IMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read Reservations data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    
    [HttpGet]
    public async Task<ActionResult<List<Reservation>>> GetReservations(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await reservationRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<ReservationResponseDto>>(data));
    }

    [HttpGet("{reservationId:int}", Name ="GetReservationById")]
    public async Task<ActionResult<Reservation>> GetReservation(int reservationId)
    {
        var reservation = await reservationRepository.GetByIdAsync(reservationId);
        if (reservation is null)
        {
            return NotFound("No Reservation found");
        }

        return Ok(mapper.Map<ReservationResponseDto>(reservation));
    }

    /// <summary>
    /// Create new Reservation
    /// </summary>
    /// <param name="reservationRequest"></param>
    /// <returns>created Reservation</returns>
    [HttpPost]
    public async Task<ActionResult<ReservationResponseDto>> AddReservation(ReservationRequestDto reservationRequest)
    {
        var reservation = mapper.Map<Reservation>(reservationRequest);
        
        await reservationRepository.AddAsync(reservation);
        
        return CreatedAtRoute("GetReservationById", 
            new { reservationId = reservation.Id },
            mapper.Map<ReservationResponseDto>(reservation));
    }
    
    /// <summary>
    /// Update Reservation
    /// </summary>
    /// <param name="reservationId"></param>
    /// <param name="reservationRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{reservationId:int}")]
    public async Task<ActionResult<ReservationResponseDto>> UpdateReservation(int reservationId,
        ReservationRequestDto reservationRequestBody)
    {
        var reservation = await reservationRepository.GetByIdAsync(reservationId);
        if (reservation is null)
        {
            return NotFound("No Reservation found");
        }
        mapper.Map(reservationRequestBody, reservation);
        await reservationRepository.UpdateAsync(reservation);
        return NoContent();
    }
    
    /// <summary>
    /// Delete Reservation by id
    /// </summary>
    /// <param name="reservationId"></param>
    /// <returns></returns>
    
    [HttpDelete("{reservationId:int}")]
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

    [HttpGet("customer/{customerId:int}")]
    public async Task<ActionResult<List<Reservation>>> GetReservationsByCustomerId(int pageNumber, int pageSize,
        int customerId)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);

        var (reservations, paginationResponse) = await reservationRepository.GetReservationsByCustomer(customerId, pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<ReservationResponseDto>>(reservations));
    }
}
