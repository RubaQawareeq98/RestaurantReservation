using AutoMapper;
using RestaurantReservation.API.Models.Customers;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerResponseDto>();
        CreateMap<CustomerRequestBodyDto, Customer>();
    }
}
