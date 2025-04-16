using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeeWithRestaurantDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW EmployeeWithRestaurantDetailsViews AS
                                    SELECT 
                                        e.Id AS EmployeeId,
                                        e.FirstName,
                                        e.LastName,
                                        e.PositionId,
                                        e.RestaurantId,
                                        r.Name AS RestaurantName,
                                        r.Address AS RestaurantAddress,
                                        r.PhoneNumber AS RestaurantPhoneNumber,
	                                    p.name as Position
                                    FROM Employees e
                                    LEFT JOIN Restaurants r ON e.RestaurantId = r.Id
                                    Left JOIN Positions p ON e.PositionId = p.Id
                                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW EmployeeWithRestaurantDetailsViews");
        }
    }
}
