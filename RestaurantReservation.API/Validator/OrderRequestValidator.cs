using FluentValidation;
using RestaurantReservation.API.Models.Orders;

namespace RestaurantReservation.API.Validator;

public abstract class OrderRequestValidator : AbstractValidator<OrderRequestBodyDto>
{
    protected OrderRequestValidator()
    {
        RuleFor(order => order.ReservationId)
            .NotEmpty();
        
        RuleFor(order => order.EmployeeId)
            .NotEmpty();
        
        RuleFor(order => order.OrderDate)
            .NotEmpty();
    }
}
