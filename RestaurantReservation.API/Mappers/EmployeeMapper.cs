using RestaurantReservation.API.Models.Employees;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class EmployeeMapper
{
    public partial Employee ToEmployee(EmployeeRequestBodyDto employeeRequestBodyDto);
    public partial EmployeeResponseDto ToEmployeeResponseDto(Employee employee);
    public partial List<EmployeeResponseDto> ToEmployeeResponseDtoList(List<Employee> employees);
}