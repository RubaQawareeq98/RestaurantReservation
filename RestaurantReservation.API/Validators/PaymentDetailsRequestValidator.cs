using FluentValidation;
using RestaurantReservation.API.Models.Orders.PaymentDetails;

namespace RestaurantReservation.API.Validators;

public class PaymentDetailsRequestValidator : AbstractValidator<PaymentDetailDto>
{
    public PaymentDetailsRequestValidator()
    {
        RuleFor(pd => pd.Amount)
            .NotNull();
        
        RuleFor(pd => pd.PaymentDate)
            .NotNull();

        RuleFor(pd => pd.PaymentMethod)
            .NotNull()
            .IsInEnum()
            .WithMessage("Payment Method must be a valid Payment Method");
    }
}
