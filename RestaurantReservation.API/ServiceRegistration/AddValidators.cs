using FluentValidation;
using FluentValidation.AspNetCore;
using RestaurantReservation.API.Validator;

namespace RestaurantReservation.API.ServiceRegistration;

public static class AddValidators
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<CustomerRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<RestaurantRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<ReservationRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<TableRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<EmployeeRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<OrderRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<PaymentDetailsRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
    }
}
