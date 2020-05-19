using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Implementation.Migrations
{
    public partial class ApartmentAddSquare : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Square",
                table: "Apartments",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                column: "Square",
                value: 100.0);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                column: "Square",
                value: 60.0);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 5, 19, 20, 28, 10, 555, DateTimeKind.Local).AddTicks(3550));

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1993, 5, 19, 20, 28, 10, 566, DateTimeKind.Local).AddTicks(1700));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Square",
                table: "Apartments");

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 5, 19, 19, 30, 16, 727, DateTimeKind.Local).AddTicks(8590));

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1993, 5, 19, 19, 30, 16, 735, DateTimeKind.Local).AddTicks(4080));
        }
    }
}
