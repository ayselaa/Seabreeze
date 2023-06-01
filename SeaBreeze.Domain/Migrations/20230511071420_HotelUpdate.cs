using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class HotelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoriesTranslates_Stories_StoriesId",
                table: "StoriesTranslates");

            migrationBuilder.DropColumn(
                name: "BedRoom",
                table: "HotelTranslates");

            migrationBuilder.DropColumn(
                name: "RoomArea",
                table: "HotelTranslates");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Hotels");

            migrationBuilder.AlterColumn<int>(
                name: "StoriesId",
                table: "StoriesTranslates",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Hotels",
                type: "numeric",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "HotelReservations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "HotelImages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_HotelReservations_HotelId",
                table: "HotelReservations",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelReservations_UserId",
                table: "HotelReservations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReservations_AspNetUsers_UserId",
                table: "HotelReservations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelReservations_Hotels_HotelId",
                table: "HotelReservations",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoriesTranslates_Stories_StoriesId",
                table: "StoriesTranslates",
                column: "StoriesId",
                principalTable: "Stories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelReservations_AspNetUsers_UserId",
                table: "HotelReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_HotelReservations_Hotels_HotelId",
                table: "HotelReservations");

            migrationBuilder.DropForeignKey(
                name: "FK_StoriesTranslates_Stories_StoriesId",
                table: "StoriesTranslates");

            migrationBuilder.DropIndex(
                name: "IX_HotelReservations_HotelId",
                table: "HotelReservations");

            migrationBuilder.DropIndex(
                name: "IX_HotelReservations_UserId",
                table: "HotelReservations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "HotelReservations");

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "HotelImages");

            migrationBuilder.AlterColumn<int>(
                name: "StoriesId",
                table: "StoriesTranslates",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BedRoom",
                table: "HotelTranslates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomArea",
                table: "HotelTranslates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "Hotels",
                type: "numeric",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "numeric",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Hotels",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_StoriesTranslates_Stories_StoriesId",
                table: "StoriesTranslates",
                column: "StoriesId",
                principalTable: "Stories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
