using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class StoryNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stories");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StoriesTranslates",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "StoriesTranslates");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
