using AutoMapper;
using RestaurantReservation.API.Models.Orders.PaymentDetails;
using RestaurantReservation.DB.Models.Entities;

namespace RestaurantReservation.API.Profiles;

public class PaymentDetailsProfile : Profile
{
    public PaymentDetailsProfile()
    {
        CreateMap<PaymentDetail, PaymentDetailDto>();
        CreateMap<PaymentDetailDto, PaymentDetail>();
    }
}
