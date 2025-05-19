using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
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
        
        
        
        builder.Services.AddSwaggerGen(c =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        builder.Services.AddControllers()
            .AddJsonOptions(options =>

            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
        
        builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
        
        builder.Services.RegisterMappers();
        
        builder.Services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ReportApiVersions = true;
        });
        
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