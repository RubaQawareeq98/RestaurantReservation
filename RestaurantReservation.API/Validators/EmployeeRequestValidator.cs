using FluentValidation;
using RestaurantReservation.API.Models.Employees;

namespace RestaurantReservation.API.Validators;

public class EmployeeRequestValidator : AbstractValidator<EmployeeRequestBodyDto>
{
    public EmployeeRequestValidator()
    {
        RuleFor(employee => employee.FirstName)
            .NotEmpty()
            .WithMessage("First name is required");
        
        RuleFor(employee => employee.LastName)
            .NotEmpty()
            .WithMessage("Last name is required");        
        
        RuleFor(employee => employee.Position)
            .NotEmpty()
            .IsInEnum() 
            .WithMessage("Position must be a valid value.");
    }
}
