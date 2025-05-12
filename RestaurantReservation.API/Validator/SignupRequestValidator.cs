using FluentValidation;
using RestaurantReservation.API.Models.Authentication;

namespace RestaurantReservation.API.Validator;

public class SignupRequestValidator : AbstractValidator<SignupRequestBodyDto>
{
    public SignupRequestValidator()
    {
        RuleFor(request => request.Username)
            .NotEmpty()
            .WithMessage("Username is required");
        
        RuleFor(request => request.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .MinimumLength(10)
            .WithMessage("Password must be at least 10 characters");
        
        RuleFor(request => request.Role)
            .NotEmpty()
            .IsInEnum()
            .WithMessage("Role is required");
    }
}
