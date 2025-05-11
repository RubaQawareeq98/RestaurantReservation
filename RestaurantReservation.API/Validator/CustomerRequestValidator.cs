using FluentValidation;
using RestaurantReservation.API.Models.Customers;

namespace RestaurantReservation.API.Validator;

public abstract class CustomerRequestValidator : AbstractValidator<CustomerRequestBodyDto>
{
    public CustomerRequestValidator()
    {
        RuleFor(customer => customer.FirstName)
            .NotEmpty()
            .WithMessage("First name cannot be empty");
        
        RuleFor(customer => customer.LastName)
            .NotEmpty()
            .WithMessage("Last name cannot be empty");
        
        RuleFor(customer => customer.Email)
            .NotEmpty()
            .WithMessage("Email cannot be empty");
        
        RuleFor(customer => customer.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number cannot be empty");
    }
}
