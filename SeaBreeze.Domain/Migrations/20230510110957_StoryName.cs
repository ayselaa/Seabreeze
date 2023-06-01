using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class StoryName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "StoriesTranslates");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "StoriesTranslates");

            migrationBuilder.RenameColumn(
                name: "Thumbnail",
                table: "Stories",
                newName: "Start");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Stories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "End",
                table: "Stories",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stories",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Stories");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stories");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Stories",
                newName: "Thumbnail");

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "StoriesTranslates",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Time",
                table: "StoriesTranslates",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
