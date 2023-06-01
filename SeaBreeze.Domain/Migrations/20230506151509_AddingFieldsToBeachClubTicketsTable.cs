using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class AddingFieldsToBeachClubTicketsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FIN",
                table: "BeachClubTickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BeachClubTickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
                name: "IsRoseBar",
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
                name: "Season",
                table: "BeachClubTickets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "SettingsId",
                table: "BeachClubTickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_BeachClubTickets_SettingsId",
                table: "BeachClubTickets",
                column: "SettingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeachClubTickets_Settings_SettingsId",
                table: "BeachClubTickets",
                column: "SettingsId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeachClubTickets_Settings_SettingsId",
                table: "BeachClubTickets");

            migrationBuilder.DropIndex(
                name: "IX_BeachClubTickets_SettingsId",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "FIN",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "IsInsured",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "IsPremium",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "IsRoseBar",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "Season",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "SettingsId",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "UsedTime",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "ValidTime",
                table: "BeachClubTickets");
        }
    }
}
