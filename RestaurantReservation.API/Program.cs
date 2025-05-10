using Microsoft.EntityFrameworkCore;
using RestaurantReservation.DB;
using RestaurantReservation.DB.Repositories.Interfaces;
using RestaurantReservation.DB.Repositories.Repos;

namespace RestaurantReservation.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
        builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}