using RestaurantReservation.API.Models.Customers;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class CustomerMapper
{
    public partial Customer ToCustomer(CustomerRequestBodyDto customerRequestBodyDto);
    public partial CustomerResponseDto ToCustomerResponseDto(Customer customer);
    public partial List<CustomerResponseDto> ToCustomerResponseDtoList(List<Customer> customers);
}
