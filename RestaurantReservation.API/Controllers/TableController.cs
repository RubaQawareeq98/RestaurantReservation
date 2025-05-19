using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Mappers;
using RestaurantReservation.API.Models.Tables;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[ApiVersion("1.0")]

[Route("api/tables")]
[Authorize]
[ApiController]
public class TableController(ITableRepository tableRepository, TableMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read Tables data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Table>>> GetTables(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await tableRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.ToTableResponseDtoList(data));
    }
    
    /// <summary>
    /// Get tables by table id
    /// </summary>
    /// <param name="tableId"></param>
    /// <returns></returns>
    [HttpGet("{tableId:int}", Name ="GetTableById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Table>> GetTable(int tableId)
    {
        var table = await tableRepository.GetByIdAsync(tableId);
        if (table is null)
        {
            return NotFound("No Table found");
        }

        return Ok(mapper.ToTableResponseDto(table));
    }

    /// <summary>
    /// Create new Table
    /// </summary>
    /// <param name="tableRequest"></param>
    /// <returns>created Table</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<TableResponseDto>> AddTable(TableRequestBodyDto tableRequest)
    {
        var table = mapper.ToTable(tableRequest);
        
        await tableRepository.AddAsync(table);
        
        return CreatedAtRoute("GetTableById", 
            new { tableId = table.Id },
            mapper.ToTableResponseDto(table));
    }
    
    /// <summary>
    /// Update Table
    /// </summary>
    /// <param name="tableId"></param>
    /// <param name="tableRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{tableId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<TableResponseDto>> UpdateTable(int tableId,
        TableRequestBodyDto tableRequestBody)
    {
        var table = await tableRepository.GetByIdAsync(tableId);
        if (table is null)
        {
            return NotFound("No Table found");
        }

        table = mapper.ToTable(tableRequestBody);
        await tableRepository.UpdateAsync(table);
        return NoContent();
    }
    
    /// <summary>
    /// Delete Table by id
    /// </summary>
    /// <param name="tableId"></param>
    /// <returns></returns>
    [HttpDelete("{tableId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<TableResponseDto>> DeleteTable(int tableId)
    {
        var table = await tableRepository.GetByIdAsync(tableId);
        if (table is null)
        {
            return NotFound("No Table found");
        }
        await tableRepository.DeleteAsync(table);
        return NoContent();
    }
}
