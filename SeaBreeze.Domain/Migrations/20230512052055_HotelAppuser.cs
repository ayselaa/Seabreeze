using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class HotelAppuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelImages_Hotels_HotelId",
                table: "HotelImages");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "HotelReservations");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "HotelImages",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImages_Hotels_HotelId",
                table: "HotelImages",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelImages_Hotels_HotelId",
                table: "HotelImages");

            migrationBuilder.AddColumn<string>(
                name: "CustomerId",
                table: "HotelReservations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "HotelId",
                table: "HotelImages",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HotelImages_Hotels_HotelId",
                table: "HotelImages",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
