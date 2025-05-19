using RestaurantReservation.API.Models.Reservations;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class ReservationMapper
{
    public partial Reservation ToReservation(ReservationRequestDto reservationRequestBodyDto);
    public partial ReservationResponseDto ToReservationResponseDto(Reservation reservation);
    public partial List<ReservationResponseDto> ToReservationResponseDtoList(List<Reservation> reservations);
}