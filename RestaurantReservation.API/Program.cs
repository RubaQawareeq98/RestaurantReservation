using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.API.Middlewares;
using RestaurantReservation.API.ServiceRegistration;
using RestaurantReservation.DB;

namespace RestaurantReservation.API;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.RegisterJwtParams();

        builder.Services.RegisterValidators();
        builder.Services.RegisterServices();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(); 
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });
        
        builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
        
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseMiddleware<ExceptionHandlingMiddleware>();
        
        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}