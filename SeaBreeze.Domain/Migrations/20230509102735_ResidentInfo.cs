using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class ResidentInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeachClubTickets_BeachClubOrders_BeachClubOrderId",
                table: "BeachClubTickets");

            migrationBuilder.AlterColumn<string>(
                name: "BeachClubOrderId",
                table: "BeachClubTickets",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ResidentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    CardId = table.Column<string>(type: "text", nullable: false),
                    FIN = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    RealEstate = table.Column<string>(type: "text", nullable: false),
                    HouseNo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentInfos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_BeachClubTickets_BeachClubOrders_BeachClubOrderId",
                table: "BeachClubTickets",
                column: "BeachClubOrderId",
                principalTable: "BeachClubOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeachClubTickets_BeachClubOrders_BeachClubOrderId",
                table: "BeachClubTickets");

            migrationBuilder.DropTable(
                name: "ResidentInfos");

            migrationBuilder.AlterColumn<string>(
                name: "BeachClubOrderId",
                table: "BeachClubTickets",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_BeachClubTickets_BeachClubOrders_BeachClubOrderId",
                table: "BeachClubTickets",
                column: "BeachClubOrderId",
                principalTable: "BeachClubOrders",
                principalColumn: "Id");
        }
    }
}
