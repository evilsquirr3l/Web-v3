using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Implementation.Migrations
{
    public partial class ApartmentResidentsAddId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ApartmentResidents",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ApartmentResidents",
                keyColumns: new[] { "ApartmentId", "ResidentId" },
                keyValues: new object[] { 1, 1 },
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ApartmentResidents",
                keyColumns: new[] { "ApartmentId", "ResidentId" },
                keyValues: new object[] { 2, 2 },
                column: "Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 5, 20, 17, 42, 40, 153, DateTimeKind.Local).AddTicks(4990));

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1993, 5, 20, 17, 42, 40, 160, DateTimeKind.Local).AddTicks(8970));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "ApartmentResidents");

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
    }
}
