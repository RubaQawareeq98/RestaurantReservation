using FluentValidation;
using RestaurantReservation.API.Models.Authentication;

namespace RestaurantReservation.API.Validator;

public abstract class LoginRequestValidator : AbstractValidator<LoginRequestBodyDto>
{
    public LoginRequestValidator()
    {
        RuleFor(loginRequest => loginRequest.Username)
            .NotEmpty();
        
        RuleFor(loginRequest => loginRequest.Password)
            .NotEmpty();
    }
}