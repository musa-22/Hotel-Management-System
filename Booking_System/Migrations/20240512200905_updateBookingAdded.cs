using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    /// <inheritdoc />
    public partial class updateBookingAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 5, 12, 21, 9, 5, 610, DateTimeKind.Local).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 5, 12, 21, 9, 5, 610, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_Date",
                value: new DateTime(2024, 5, 12, 21, 9, 5, 610, DateTimeKind.Local).AddTicks(3275));

            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created_Date",
                value: new DateTime(2024, 5, 12, 21, 9, 5, 610, DateTimeKind.Local).AddTicks(3277));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 5, 9, 12, 46, 55, 768, DateTimeKind.Local).AddTicks(3));

            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 5, 9, 12, 46, 55, 768, DateTimeKind.Local).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_Date",
                value: new DateTime(2024, 5, 9, 12, 46, 55, 768, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created_Date",
                value: new DateTime(2024, 5, 9, 12, 46, 55, 768, DateTimeKind.Local).AddTicks(52));
        }
    }
}
