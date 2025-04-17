using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.DB.Migrations
{
    /// <inheritdoc />
    public partial class CustomersWithReservationsGreateThanPartySizeProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql(@"CREATE PROCEDURE sp_CustomersWithPartySizeGreaterThanValue (@PartySize INT)
									AS
									BEGIN
										select c.*
										from Reservations r
										Join Customers c
										on r.CustomerId = c.Id
										where r.PartySize > @partySize
									END");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
	        migrationBuilder.Sql("DROP PROCEDURE sp_CustomersWithPartySizeGreaterThanValue");
        }
    }
}
