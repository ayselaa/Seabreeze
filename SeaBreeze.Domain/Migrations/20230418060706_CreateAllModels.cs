using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class CreateAllModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelEssentialTranslate_HotelEssentials_HotelEssentialsId",
                table: "HotelEssentialTranslate");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelEssentialTranslate",
                table: "HotelEssentialTranslate");

            migrationBuilder.RenameTable(
                name: "HotelEssentialTranslate",
                newName: "HotelEssentialTranslates");

            migrationBuilder.RenameIndex(
                name: "IX_HotelEssentialTranslate_HotelEssentialsId",
                table: "HotelEssentialTranslates",
                newName: "IX_HotelEssentialTranslates_HotelEssentialsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelEssentialTranslates",
                table: "HotelEssentialTranslates",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BeachClubOrders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    BuyTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeachClubs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PremiumTicketInfo = table.Column<string>(type: "text", nullable: false),
                    BeachClubInfo = table.Column<string>(type: "text", nullable: false),
                    EnsuranceInfo = table.Column<string>(type: "text", nullable: false),
                    Banner = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    FIN = table.Column<string>(type: "text", nullable: false),
                    IsResident = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelImages",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelImages", x => x.Name);
                    table.ForeignKey(
                        name: "FK_HotelImages_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelReservations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    From = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    To = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HotelId = table.Column<int>(type: "integer", nullable: false),
                    BuyTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CustomerId = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelReservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LangCode = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    RoomArea = table.Column<string>(type: "text", nullable: false),
                    BedRoom = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelTranslates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Residents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FIN = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BannerImage = table.Column<string>(type: "text", nullable: false),
                    Thumbnail = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BeachClubTickets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Sesason = table.Column<string>(type: "text", nullable: false),
                    ValidTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UsedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsPremium = table.Column<bool>(type: "boolean", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsInsured = table.Column<bool>(type: "boolean", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    FIN = table.Column<string>(type: "text", nullable: false),
                    BeachClubOrderId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeachClubTickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeachClubTickets_BeachClubOrders_BeachClubOrderId",
                        column: x => x.BeachClubOrderId,
                        principalTable: "BeachClubOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StoriesTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LangCode = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StoriesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoriesTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoriesTranslates_Stories_StoriesId",
                        column: x => x.StoriesId,
                        principalTable: "Stories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeachClubTickets_BeachClubOrderId",
                table: "BeachClubTickets",
                column: "BeachClubOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelImages_HotelId",
                table: "HotelImages",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_StoriesTranslates_StoriesId",
                table: "StoriesTranslates",
                column: "StoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelEssentialTranslates_HotelEssentials_HotelEssentialsId",
                table: "HotelEssentialTranslates",
                column: "HotelEssentialsId",
                principalTable: "HotelEssentials",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelEssentialTranslates_HotelEssentials_HotelEssentialsId",
                table: "HotelEssentialTranslates");

            migrationBuilder.DropTable(
                name: "BeachClubs");

            migrationBuilder.DropTable(
                name: "BeachClubTickets");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "HotelImages");

            migrationBuilder.DropTable(
                name: "HotelReservations");

            migrationBuilder.DropTable(
                name: "HotelTranslates");

            migrationBuilder.DropTable(
                name: "Residents");

            migrationBuilder.DropTable(
                name: "StoriesTranslates");

            migrationBuilder.DropTable(
                name: "BeachClubOrders");

            migrationBuilder.DropTable(
                name: "Stories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HotelEssentialTranslates",
                table: "HotelEssentialTranslates");

            migrationBuilder.RenameTable(
                name: "HotelEssentialTranslates",
                newName: "HotelEssentialTranslate");

            migrationBuilder.RenameIndex(
                name: "IX_HotelEssentialTranslates_HotelEssentialsId",
                table: "HotelEssentialTranslate",
                newName: "IX_HotelEssentialTranslate_HotelEssentialsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HotelEssentialTranslate",
                table: "HotelEssentialTranslate",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelEssentialTranslate_HotelEssentials_HotelEssentialsId",
                table: "HotelEssentialTranslate",
                column: "HotelEssentialsId",
                principalTable: "HotelEssentials",
                principalColumn: "Id");
        }
    }
}
