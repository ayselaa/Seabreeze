using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class PayRiff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PayriffOrderId",
                table: "BeachClubOrders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PayriffOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orderId = table.Column<string>(type: "text", nullable: false),
                    sessionId = table.Column<string>(type: "text", nullable: false),
                    paymentUrl = table.Column<string>(type: "text", nullable: false),
                    transactionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayriffOrders", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeachClubOrders_PayriffOrderId",
                table: "BeachClubOrders",
                column: "PayriffOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_BeachClubOrders_PayriffOrders_PayriffOrderId",
                table: "BeachClubOrders",
                column: "PayriffOrderId",
                principalTable: "PayriffOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BeachClubOrders_PayriffOrders_PayriffOrderId",
                table: "BeachClubOrders");

            migrationBuilder.DropTable(
                name: "PayriffOrders");

            migrationBuilder.DropIndex(
                name: "IX_BeachClubOrders_PayriffOrderId",
                table: "BeachClubOrders");

            migrationBuilder.DropColumn(
                name: "PayriffOrderId",
                table: "BeachClubOrders");
        }
    }
}
