using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking_System.Migrations
{
    /// <inheritdoc />
    public partial class addnewprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 1,
                column: "Created_Date",
                value: new DateTime(2024, 5, 8, 14, 2, 59, 783, DateTimeKind.Local).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 2,
                column: "Created_Date",
                value: new DateTime(2024, 5, 8, 14, 2, 59, 783, DateTimeKind.Local).AddTicks(4512));

            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 3,
                column: "Created_Date",
                value: new DateTime(2024, 5, 8, 14, 2, 59, 783, DateTimeKind.Local).AddTicks(4514));

            migrationBuilder.UpdateData(
                table: "RoomTypesDb",
                keyColumn: "Id",
                keyValue: 4,
                column: "Created_Date",
                value: new DateTime(2024, 5, 8, 14, 2, 59, 783, DateTimeKind.Local).AddTicks(4517));
        }
    }
}
