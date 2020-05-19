using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Implementation.Migrations
{
    public partial class CityChangePopulationTypeToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Population",
                table: "Cities",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Population",
                value: 2000000);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 5, 19, 20, 57, 50, 938, DateTimeKind.Local).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1993, 5, 19, 20, 57, 50, 947, DateTimeKind.Local).AddTicks(2920));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Population",
                table: "Cities",
                type: "float",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1,
                column: "Population",
                value: 2000000.0);

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
    }
}
