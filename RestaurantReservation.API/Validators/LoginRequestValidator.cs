using FluentValidation;
using RestaurantReservation.API.Models.Authentication;

namespace RestaurantReservation.API.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequestBodyDto>
{
    public LoginRequestValidator()
    {
        RuleFor(loginRequest => loginRequest.Username)
            .NotEmpty();
        
        RuleFor(loginRequest => loginRequest.Password)
            .NotEmpty();
    }
}