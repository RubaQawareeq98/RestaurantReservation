using FluentValidation;
using RestaurantReservation.API.Models.Tables;

namespace RestaurantReservation.API.Validator;

public abstract class TableRequestValidator : AbstractValidator<TableRequestBodyDto>
{
    protected TableRequestValidator()
    {
        RuleFor(table => table.Capacity)
            .GreaterThan(0);
    }
}
