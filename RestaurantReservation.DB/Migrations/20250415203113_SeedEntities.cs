using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantReservation.DB.Migrations
{
    /// <inheritdoc />
    public partial class SeedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "johndoe@gmail.com", "John", "Doe", "12345678" },
                    { 2, "ruban@gmail.com", "Ruba", "Qa", "42345678" },
                    { 3, "ali@gmail.com", "Ali", "Doe", "52345678" },
                    { 4, "hiba@gmail.com", "Hiba", "Doe", "62345678" },
                    { 5, "mohammad@gmail.com", "Mohammad", "Doe", "52345678" }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Manager" },
                    { 2, "Waiter" },
                    { 3, "Cashier" },
                    { 4, "Chef" },
                    { 5, "Dishwasher" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "Id", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Nablus", "Restaurant 1", "256478912" },
                    { 2, "Jenin", "Restaurant 2", "256478459" },
                    { 3, "Nablus", "Restaurant 3", "123478912" },
                    { 4, "Jericho", "Restaurant 4", "785478912" },
                    { 5, "Nablus", "Restaurant 5", "587478912" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "PositionId", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Masa", "Ahmad", 1, 1 },
                    { 2, "Khaled", "Isa", 2, 2 },
                    { 3, "Jehad", "Mohammad", 3, 3 },
                    { 4, "Wael", "Khaled", 4, 4 },
                    { 5, "Waleed", "Awad", 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Description", "Name", "Price", "RestaurantId" },
                values: new object[,]
                {
                    { 1, "Description1", "Home", 10m, 1 },
                    { 2, "Description2", "Menu", 10m, 2 },
                    { 3, "Description3", "Menu", 10m, 3 },
                    { 4, "Description4", "Menu", 10m, 4 },
                    { 5, "Description5", "Menu", 10m, 5 }
                });

            migrationBuilder.InsertData(
                table: "OpeningHours",
                columns: new[] { "Id", "CloseHour", "DayOfWeek", "OpenHour", "RestaurantId" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 17, 0, 0, 0), 1, new TimeSpan(0, 9, 0, 0, 0), 1 },
                    { 2, new TimeSpan(0, 17, 0, 0, 0), 2, new TimeSpan(0, 10, 30, 0, 0), 1 },
                    { 3, new TimeSpan(0, 17, 0, 0, 0), 3, new TimeSpan(0, 9, 0, 0, 0), 2 },
                    { 4, new TimeSpan(0, 20, 0, 0, 0), 4, new TimeSpan(0, 9, 0, 0, 0), 3 },
                    { 5, new TimeSpan(0, 21, 0, 0, 0), 5, new TimeSpan(0, 9, 0, 0, 0), 3 },
                    { 6, new TimeSpan(0, 18, 0, 0, 0), 6, new TimeSpan(0, 10, 0, 0, 0), 3 },
                    { 7, new TimeSpan(0, 18, 0, 0, 0), 0, new TimeSpan(0, 8, 0, 0, 0), 4 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "Id", "Capacity", "RestaurantId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 2, 4, 2 },
                    { 3, 5, 3 },
                    { 4, 6, 4 },
                    { 5, 7, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CustomerId", "PartySize", "ReservationDate", "RestaurantId", "TableId" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2025, 4, 15, 7, 55, 55, 612, DateTimeKind.Local).AddTicks(8581), 1, 1 },
                    { 2, 2, 4, new DateTime(2025, 4, 20, 7, 46, 45, 612, DateTimeKind.Local), 2, 2 },
                    { 3, 3, 11, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 3, 3 },
                    { 4, 4, 5, new DateTime(2025, 3, 20, 7, 46, 45, 612, DateTimeKind.Local), 4, 4 },
                    { 5, 5, 4, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "EmployeeId", "OrderDate", "ReservationId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 1 },
                    { 2, 2, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 2 },
                    { 3, 3, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 3 },
                    { 4, 4, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 4 },
                    { 5, 5, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 5 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "MenuItemId", "OrderId", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 1 },
                    { 3, 3, 3, 1 },
                    { 4, 4, 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "PaymentDetails",
                columns: new[] { "OrderId", "Amount", "PaymentDate", "PaymentMethod", "PaymentNumber" },
                values: new object[,]
                {
                    { 1, 4m, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 0, 1 },
                    { 2, 5m, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 0, 2 },
                    { 3, 6m, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 1, 3 },
                    { 4, 7m, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 1, 4 },
                    { 5, 8m, new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), 1, 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OpeningHours",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentDetails",
                keyColumn: "OrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PaymentDetails",
                keyColumn: "OrderId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PaymentDetails",
                keyColumn: "OrderId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PaymentDetails",
                keyColumn: "OrderId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PaymentDetails",
                keyColumn: "OrderId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Restaurants",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
