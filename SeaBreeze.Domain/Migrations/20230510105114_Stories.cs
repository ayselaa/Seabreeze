using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class Stories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "Stories");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "StoriesTranslates",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "StoriesTranslates");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Stories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
