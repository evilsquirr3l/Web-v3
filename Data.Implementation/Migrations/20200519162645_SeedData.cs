using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Implementation.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "HouseId", "Type" },
                values: new object[,]
                {
                    { 1, null, "Serdychka house" },
                    { 2, null, "Hostel" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Ukraine" });

            migrationBuilder.InsertData(
                table: "Residents",
                columns: new[] { "Id", "BirthDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2002, 5, 19, 19, 26, 33, 63, DateTimeKind.Local).AddTicks(1780), "Max Snizhok" },
                    { 2, new DateTime(1993, 5, 19, 19, 26, 33, 70, DateTimeKind.Local).AddTicks(6390), "Kurtka Bayne" }
                });

            migrationBuilder.InsertData(
                table: "ApartmentResidents",
                columns: new[] { "ApartmentId", "ResidentId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ApartmentResidents",
                columns: new[] { "ApartmentId", "ResidentId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name", "Population" },
                values: new object[] { 1, 1, "Kyiv", 2000000.0 });

            migrationBuilder.InsertData(
                table: "Streets",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[] { 1, 1, "Khreshchatyk" });

            migrationBuilder.InsertData(
                table: "Houses",
                columns: new[] { "Id", "Latitude", "Longitude", "StreetId" },
                values: new object[] { 1, 50.439999999999998, 30.52, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ApartmentResidents",
                keyColumns: new[] { "ApartmentId", "ResidentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ApartmentResidents",
                keyColumns: new[] { "ApartmentId", "ResidentId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Houses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Apartments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Residents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Streets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
