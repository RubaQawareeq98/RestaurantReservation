using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.Validator;
using RestaurantReservation.DB;
using RestaurantReservation.DB.Repositories.Interfaces;
using RestaurantReservation.DB.Repositories.Repos;

namespace RestaurantReservation.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddFluentValidationAutoValidation();
        builder.Services.AddValidatorsFromAssemblyContaining<CustomerRequestValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<RestaurantRequestValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<ReservationRequestValidator>();
        builder.Services.AddValidatorsFromAssemblyContaining<TableRequestValidator>();


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(); 
        builder.Services.AddControllers();
        
        builder.Services.AddDbContext<RestaurantReservationDbContext>();
        builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
        builder.Services.AddScoped<IOrderRepository, OrderRepository>();
        builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
        builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
        builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        builder.Services.AddScoped<ITableRepository, TableRepository>();
        
        
        builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
        
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddOpenApi();

        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}