using FluentValidation;
using RestaurantReservation.API.Models.Tables;

namespace RestaurantReservation.API.Validator;

public class TableRequestValidator : AbstractValidator<TableRequestBodyDto>
{
    public TableRequestValidator()
    {
        RuleFor(table => table.Capacity)
            .GreaterThan(0);
    }
}
