using Microsoft.EntityFrameworkCore.Migrations;

namespace data.implementation.Migrations
{
    public partial class ApartmentAddField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Apartments",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Apartments");
        }
    }
}
