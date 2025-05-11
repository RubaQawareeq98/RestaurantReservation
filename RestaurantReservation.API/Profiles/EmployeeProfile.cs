using AutoMapper;
using RestaurantReservation.API.Models.Employees;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeResponseDto>();
        CreateMap<EmployeeRequestBodyDto, Employee>();
    }
}
