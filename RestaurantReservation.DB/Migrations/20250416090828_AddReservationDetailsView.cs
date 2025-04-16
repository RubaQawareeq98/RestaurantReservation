using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.DB.Migrations
{
    /// <inheritdoc />
    public partial class AddReservationDetailsView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW [dbo].[ReservationDetailsViews]
                                  As SELECT 
                                        r.Id AS ReservationId,
                                        r.ReservationDate,
                                        r.PartySize,
                                        r.TableId,
                                        c.Id AS CustomerId,
                                        c.FirstName AS CustomerFirstName,
                                        c.LastName AS CustomerLastName,
                                        c.PhoneNumber AS CustomerPhone,
                                        c.Email AS CustomerEmail,
                                        res.Id AS RestaurantId,
                                        res.Name AS RestaurantName,
                                        res.Address AS RestaurantAddress,
			                            CONCAT(o.DayOfWeek, o.OpenHour, ' - ', o.CloseHour) as OpenHour
			                            
                                    FROM Reservations r
                                    LEFT JOIN Customers c ON r.CustomerId = c.Id
                                    LEFT JOIN Restaurants res ON r.RestaurantId = res.Id
		                            LEFT JOIN OpeningHours o ON r.Id = o.RestaurantId
                            ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW [dbo].[ReservationDetailsViews]");
        }
    }
}
