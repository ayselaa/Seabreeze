using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class HotelEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Hotels",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Hotels");
        }
    }
}
