using FluentValidation;
using FluentValidation.AspNetCore;
using RestaurantReservation.API.Models.Authentication;
using RestaurantReservation.API.Models.Customers;
using RestaurantReservation.API.Models.Employees;
using RestaurantReservation.API.Models.Orders;
using RestaurantReservation.API.Models.Orders.PaymentDetails;
using RestaurantReservation.API.Models.Reservations;
using RestaurantReservation.API.Models.Restaurants;
using RestaurantReservation.API.Models.Tables;
using RestaurantReservation.API.Validators;

namespace RestaurantReservation.API.ServiceRegistration;

public static class AddValidators
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();

        services.AddScoped<IValidator<SignupRequestBodyDto>, SignupRequestValidator>();
        services.AddScoped<IValidator<LoginRequestBodyDto>, LoginRequestValidator>();
        services.AddScoped<IValidator<CustomerRequestBodyDto>, CustomerRequestValidator>();
        services.AddScoped<IValidator<EmployeeRequestBodyDto>, EmployeeRequestValidator>();
        services.AddScoped<IValidator<OrderRequestBodyDto>, OrderRequestValidator>();
        services.AddScoped<IValidator<PaymentDetailDto>, PaymentDetailsRequestValidator>();
        services.AddScoped<IValidator<ReservationRequestDto>, ReservationRequestValidator>();
        services.AddScoped<IValidator<RestaurantRequestBodyDto>, RestaurantRequestValidator>();
        services.AddScoped<IValidator<TableRequestBodyDto>, TableRequestValidator>();
       
    }
}
