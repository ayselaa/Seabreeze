using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class CreateSettingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FIN",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "IsInsured",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "IsPremium",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "Sesason",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "UsedTime",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "ValidTime",
                table: "BeachClubTickets");

            migrationBuilder.RenameColumn(
                name: "BuyTime",
                table: "BeachClubOrders",
                newName: "CreatedAt");

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "BeachClubOrders",
                newName: "BuyTime");

            migrationBuilder.AddColumn<string>(
                name: "FIN",
                table: "BeachClubTickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsInsured",
                table: "BeachClubTickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPremium",
                table: "BeachClubTickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "BeachClubTickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Sesason",
                table: "BeachClubTickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UsedTime",
                table: "BeachClubTickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ValidTime",
                table: "BeachClubTickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
