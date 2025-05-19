using FluentValidation;
using RestaurantReservation.API.Models.Reservations;

namespace RestaurantReservation.API.Validators;

public class ReservationRequestValidator : AbstractValidator<ReservationRequestDto>
{
    public ReservationRequestValidator()
    {
        RuleFor(reservation => reservation.ReservationDate)
            .NotNull()
            .GreaterThan(DateTime.Now)
            .WithMessage("Reservation date cannot be in the past.");

        RuleFor(reservation => reservation.PartySize)
            .GreaterThan(0);
    }
}
