using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Implementation.Migrations
{
    public partial class AddFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments");

            migrationBuilder.AlterColumn<int>(
                name: "HouseId",
                table: "Apartments",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HouseId", "Type" },
                values: new object[] { 1, "Serdychka flat" });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HouseId", "Type" },
                values: new object[] { 1, "Nirvana" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments");

            migrationBuilder.AlterColumn<int>(
                name: "HouseId",
                table: "Apartments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HouseId", "Type" },
                values: new object[] { null, "Serdychka house" });

            migrationBuilder.UpdateData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HouseId", "Type" },
                values: new object[] { null, "Hostel" });

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2002, 5, 19, 19, 26, 33, 63, DateTimeKind.Local).AddTicks(1780));

            migrationBuilder.UpdateData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1993, 5, 19, 19, 26, 33, 70, DateTimeKind.Local).AddTicks(6390));

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
