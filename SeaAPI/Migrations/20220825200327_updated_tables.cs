using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaAPI.Migrations
{
    public partial class updated_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "companyId",
                table: "BookingModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cost",
                table: "BookingModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "time",
                table: "BookingModel",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "companyId",
                table: "BookingModel");

            migrationBuilder.DropColumn(
                name: "cost",
                table: "BookingModel");

            migrationBuilder.DropColumn(
                name: "time",
                table: "BookingModel");
        }
    }
}
