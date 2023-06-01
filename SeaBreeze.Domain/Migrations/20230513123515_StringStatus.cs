using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class StringStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "orderStatus",
                table: "PayriffOrders");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "PayriffOrders",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "PayriffOrders");

            migrationBuilder.AddColumn<int>(
                name: "orderStatus",
                table: "PayriffOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
