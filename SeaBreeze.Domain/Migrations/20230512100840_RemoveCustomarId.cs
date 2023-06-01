using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class RemoveCustomarId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "BeachClubOrders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "BeachClubOrders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
