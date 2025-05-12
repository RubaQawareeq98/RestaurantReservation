using System.Text.Json;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantReservation.API.Models.Customers;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;

namespace RestaurantReservation.API.Controllers;

[ApiVersion("1.0")]
[Route("api/customers")]
[Authorize]
[ApiController]
public class CustomerController(ICustomerRepository customerRepository, IMapper mapper) : ControllerBase
{
    private int _maxPageSize = 80;
    
    /// <summary>
    /// Read customer data
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <returns></returns>
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<List<Customer>>> GetCustomer(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            return BadRequest("Page number and page size must be greater than 0");
        }
        
        _maxPageSize = Math.Min(_maxPageSize, pageSize);
        
        var (data, paginationResponse) = await customerRepository.GetAllAsync(pageNumber, pageSize);
        Response.Headers.Append("X-Pagination-Metadata", JsonSerializer.Serialize(paginationResponse));

        return Ok(mapper.Map<List<CustomerResponseDto>>(data));
    }
    
    /// <summary>
    /// Get customer by customer ID
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{customerId:int}", Name ="GetCustomerById")]
    public async Task<ActionResult<Customer>> GetCustomer(int customerId)
    {
        var customer = await customerRepository.GetByIdAsync(customerId);
        if (customer is null)
        {
            return NotFound("No customer found");
        }

        return Ok(mapper.Map<CustomerResponseDto>(customer));
    }

    /// <summary>
    /// Create new customer
    /// </summary>
    /// <param name="customerRequest"></param>
    /// <returns>created customer</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<CustomerResponseDto>> AddCustomer(CustomerRequestBodyDto customerRequest)
    {
        var customer = mapper.Map<Customer>(customerRequest);
        
        await customerRepository.AddAsync(customer);
        
        return CreatedAtRoute("GetCustomerById", 
            new { customerId = customer.Id },
            mapper.Map<CustomerResponseDto>(customer));
    }
    
    /// <summary>
    /// Update customer
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="customerRequestBody"></param>
    /// <returns></returns>
    [HttpPut("{customerId:int}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<CustomerResponseDto>> UpdateCustomer(int customerId,
        CustomerRequestBodyDto customerRequestBody)
    {
        var customer = await customerRepository.GetByIdAsync(customerId);
        if (customer is null)
        {
            return NotFound("No customer found");
        }
        mapper.Map(customerRequestBody, customer);
        await customerRepository.UpdateAsync(customer);
        return NoContent();
    }
    
    /// <summary>
    /// Delete customer by id
    /// </summary>
    /// <param name="customerId"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpDelete("{customerId:int}")]
    public async Task<ActionResult<CustomerResponseDto>> DeleteCustomer(int customerId)
    {
        var customer = await customerRepository.GetByIdAsync(customerId);
        if (customer is null)
        {
            return NotFound("No customer found");
        }
        await customerRepository.DeleteAsync(customer);
        return NoContent();
    }
}
