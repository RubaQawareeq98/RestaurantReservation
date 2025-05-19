using FluentValidation;
using RestaurantReservation.API.Models.Tables;

namespace RestaurantReservation.API.Validators;

public class TableRequestValidator : AbstractValidator<TableRequestBodyDto>
{
    public TableRequestValidator()
    {
        RuleFor(table => table.Capacity)
            .GreaterThan(0);
    }
}
