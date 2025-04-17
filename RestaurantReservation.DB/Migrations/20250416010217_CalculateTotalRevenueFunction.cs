using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.DB.Migrations
{
    /// <inheritdoc />
    public partial class CalculateTotalRevenueFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"CREATE FUNCTION fn_CalculateTotalRevenue (@restaurantId INT)
									RETURNS decimal(6,2) AS
									BEGIN
										DECLARE @totalRevenue decimal(6,2);

											WITH RestaurantItems AS
												(
													SELECT oi.quantity as quantity,
													i.price as price
													from Reservations r
													join Orders o on r.Id = o.ReservationId
													join OrderItems oi on o.Id = oi.OrderId
													join MenuItems i on oi.MenuItemId = i.Id
													where r.RestaurantId = 1
												)
											SELECT @totalRevenue = SUM(quantity * price)
											FROM RestaurantItems

											RETURN @totalRevenue
									END");	
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"DROP FUNCTION fn_CalculateTotalRevenue");
        }
    }
}
