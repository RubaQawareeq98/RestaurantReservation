using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Tables;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[Route("api/tables")]
[Authorize]
[ApiController]
public class TableController(ITableRepository tableRepository, IMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read Tables data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    
    [HttpGet]
    public async Task<ActionResult<List<Table>>> GetTables(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await tableRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<TableResponseDto>>(data));
    }

    [HttpGet("{tableId:int}", Name ="GetTableById")]
    public async Task<ActionResult<Table>> GetTable(int tableId)
    {
        var table = await tableRepository.GetByIdAsync(tableId);
        if (table is null)
        {
            return NotFound("No Table found");
        }

        return Ok(mapper.Map<TableResponseDto>(table));
    }

    /// <summary>
    /// Create new Table
    /// </summary>
    /// <param name="tableRequest"></param>
    /// <returns>created Table</returns>
    [HttpPost]
    public async Task<ActionResult<TableResponseDto>> AddTable(TableRequestBodyDto tableRequest)
    {
        var table = mapper.Map<Table>(tableRequest);
        
        await tableRepository.AddAsync(table);
        
        return CreatedAtRoute("GetTableById", 
            new { tableId = table.Id },
            mapper.Map<TableResponseDto>(table));
    }
    
    /// <summary>
    /// Update Table
    /// </summary>
    /// <param name="tableId"></param>
    /// <param name="tableRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{tableId:int}")]
    public async Task<ActionResult<TableResponseDto>> UpdateTable(int tableId,
        TableRequestBodyDto tableRequestBody)
    {
        var table = await tableRepository.GetByIdAsync(tableId);
        if (table is null)
        {
            return NotFound("No Table found");
        }
        mapper.Map(tableRequestBody, table);
        await tableRepository.UpdateAsync(table);
        return NoContent();
    }
    
    /// <summary>
    /// Delete Table by id
    /// </summary>
    /// <param name="tableId"></param>
    /// <returns></returns>
    
    [HttpDelete("{tableId:int}")]
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
