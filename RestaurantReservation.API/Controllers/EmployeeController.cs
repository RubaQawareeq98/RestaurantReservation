using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Employees;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[ApiVersion("1.0")]
[Route("api/employees")]
[Authorize]
[ApiController]
public class EmployeeController(IEmployeeRepository employeeRepository, IMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read Employees data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<Employee>>> GetEmployees(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await employeeRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<EmployeeResponseDto>>(data));
    }

    [HttpGet("{employeeId:int}", Name ="GetEmployeeById")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<Employee>> GetEmployee(int employeeId)
    {
        var employee = await employeeRepository.GetByIdAsync(employeeId);
        if (employee is null)
        {
            return NotFound("No employee found");
        }

        return Ok(mapper.Map<EmployeeResponseDto>(employee));
    }

    /// <summary>
    /// Create new employee
    /// </summary>
    /// <param name="employeeRequest"></param>
    /// <returns>created employee</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<EmployeeResponseDto>> AddEmployee(EmployeeRequestBodyDto employeeRequest)
    {
        var employee = mapper.Map<Employee>(employeeRequest);
        
        await employeeRepository.AddAsync(employee);
        
        return CreatedAtRoute("GetEmployeeById", 
            new { employeeId = employee.Id },
            mapper.Map<EmployeeResponseDto>(employee));
    }
    
    /// <summary>
    /// Update employee
    /// </summary>
    /// <param name="employeeId"></param>
    /// <param name="employeeRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{employeeId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<EmployeeResponseDto>> UpdateEmployee(int employeeId,
        EmployeeRequestBodyDto employeeRequestBody)
    {
        var employee = await employeeRepository.GetByIdAsync(employeeId);
        if (employee is null)
        {
            return NotFound("No employee found");
        }
        mapper.Map(employeeRequestBody, employee);
        await employeeRepository.UpdateAsync(employee);
        return NoContent();
    }
    
    /// <summary>
    /// Delete employee by id
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{employeeId:int}")]
    public async Task<ActionResult<EmployeeResponseDto>> DeleteEmployee(int employeeId)
    {
        var employee = await employeeRepository.GetByIdAsync(employeeId);
        if (employee is null)
        {
            return NotFound("No employee found");
        }
        await employeeRepository.DeleteAsync(employee);
        return NoContent();
    }

    [HttpGet("managers")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<EmployeeResponseDto>>> GetAllManagers(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (managers, paginationResponse) = await employeeRepository.GetManagersAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<EmployeeResponseDto>>(managers));
    }

    [HttpGet("{employeeId:int}/average-order-amount")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<decimal>> GetEmployeeOrderAverageAmount(int employeeId)
    {
        var employee = await employeeRepository.GetByIdAsync(employeeId);
        if (employee is null)
        {
            return NotFound("Employee not found");
        }
        var totalAverageAmount = await employeeRepository.CalculateAverageOrderAmount(employeeId);
        
        return Ok(
            new
        {
            totalAverageAmount
        });
    }
}
