using FluentValidation;
using RestaurantReservation.API.Models.Restaurants;

namespace RestaurantReservation.API.Validators;

public class RestaurantRequestValidator : AbstractValidator<RestaurantRequestBodyDto>
{
    public RestaurantRequestValidator()
    {
        RuleFor(res => res.Name)
            .NotEmpty()
            .WithMessage("Restaurant name is required")
            .MinimumLength(3);
        
        RuleFor(res => res.Address)
            .NotEmpty()
            .WithMessage("Restaurant address is required")
            .MinimumLength(3);

        RuleFor(res => res.PhoneNumber)
            .NotEmpty()
            .WithMessage("Restaurant phone number is required")
            .MinimumLength(10);
    }
}
