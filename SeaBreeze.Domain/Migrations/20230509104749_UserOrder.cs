using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class UserOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "BeachClubOrders",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BeachClubOrders_AppUserId",
                table: "BeachClubOrders",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeachClubOrders_AspNetUsers_AppUserId",
                table: "BeachClubOrders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeachClubOrders_AspNetUsers_AppUserId",
                table: "BeachClubOrders");

            migrationBuilder.DropIndex(
                name: "IX_BeachClubOrders_AppUserId",
                table: "BeachClubOrders");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BeachClubOrders");
        }
    }
}
