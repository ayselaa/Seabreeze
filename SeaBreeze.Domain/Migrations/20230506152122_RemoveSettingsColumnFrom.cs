using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class RemoveSettingsColumnFrom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeachClubTickets_Settings_SettingsId",
                table: "BeachClubTickets");

            migrationBuilder.DropIndex(
                name: "IX_BeachClubTickets_SettingsId",
                table: "BeachClubTickets");

            migrationBuilder.DropColumn(
                name: "SettingsId",
                table: "BeachClubTickets");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BeachClubTickets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "FIN",
                table: "BeachClubTickets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BeachClubTickets",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FIN",
                table: "BeachClubTickets",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SettingsId",
                table: "BeachClubTickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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
    }
}
