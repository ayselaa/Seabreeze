using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class HotelTranslates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HotelId",
                table: "HotelTranslates",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelTranslates_HotelId",
                table: "HotelTranslates",
                column: "HotelId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelTranslates_Hotels_HotelId",
                table: "HotelTranslates",
                column: "HotelId",
                principalTable: "Hotels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelTranslates_Hotels_HotelId",
                table: "HotelTranslates");

            migrationBuilder.DropIndex(
                name: "IX_HotelTranslates_HotelId",
                table: "HotelTranslates");

            migrationBuilder.DropColumn(
                name: "HotelId",
                table: "HotelTranslates");
        }
    }
}
