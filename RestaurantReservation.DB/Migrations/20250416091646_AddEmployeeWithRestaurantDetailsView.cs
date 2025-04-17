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
            migrationBuilder.Sql(@"CREATE VIEW EmployeeWithRestaurantDetails AS
                                    SELECT 
                                        e.Id AS EmployeeId,
                                        e.FirstName,
                                        e.LastName,
                                        e.Position,
                                        e.RestaurantId,
                                        r.Name AS RestaurantName,
                                        r.Address AS RestaurantAddress,
                                        r.PhoneNumber AS RestaurantPhoneNumber
                                    FROM Employees e
                                    JOIN Restaurants r ON e.RestaurantId = r.Id
                                    ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW EmployeeWithRestaurantDetails");
        }
    }
}
