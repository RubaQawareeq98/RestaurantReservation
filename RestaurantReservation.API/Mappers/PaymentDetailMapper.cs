using RestaurantReservation.API.Models.Orders.PaymentDetails;
using RestaurantReservation.DB.Models.Entities;
using Riok.Mapperly.Abstractions;

namespace RestaurantReservation.API.Mappers;

[Mapper]
public partial class PaymentDetailMapper
{
    public partial PaymentDetailDto ToPaymentDetailDto(PaymentDetail paymentDetail);
    public partial PaymentDetail FromPaymentDetailDto(PaymentDetailDto paymentDetailDto);
    
}