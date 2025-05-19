using FluentValidation;
using RestaurantReservation.API.Models.Orders;

namespace RestaurantReservation.API.Validators;

public class OrderRequestValidator : AbstractValidator<OrderRequestBodyDto>
{
    public OrderRequestValidator()
    {
        RuleFor(order => order.ReservationId)
            .NotEmpty();
        
        RuleFor(order => order.EmployeeId)
            .NotEmpty();
        
        RuleFor(order => order.OrderDate)
            .NotEmpty();
    }
}
