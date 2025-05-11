using FluentValidation;
using RestaurantReservation.API.Models.Orders.PaymentDetails;

namespace RestaurantReservation.API.Validator;

public abstract class PaymentDetailsRequestValidator : AbstractValidator<PaymentDetailDto>
{
    protected PaymentDetailsRequestValidator()
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
