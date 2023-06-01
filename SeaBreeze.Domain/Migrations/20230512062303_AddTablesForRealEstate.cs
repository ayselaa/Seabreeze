using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class AddTablesForRealEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstateFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Logo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateFeatureTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LangCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateFeatureTranslates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HotelEssentialsRealEstate",
                columns: table => new
                {
                    EssentialsId = table.Column<int>(type: "integer", nullable: false),
                    RealEstatesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelEssentialsRealEstate", x => new { x.EssentialsId, x.RealEstatesId });
                    table.ForeignKey(
                        name: "FK_HotelEssentialsRealEstate_HotelEssentials_EssentialsId",
                        column: x => x.EssentialsId,
                        principalTable: "HotelEssentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelEssentialsRealEstate_RealEstates_RealEstatesId",
                        column: x => x.RealEstatesId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LangCode = table.Column<string>(type: "text", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false),
                    RealEstateId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateDetails_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstateGalleries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    RealEstateId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateGalleries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateGalleries_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstateRealEstateFeature",
                columns: table => new
                {
                    RealEstateFeaturesId = table.Column<int>(type: "integer", nullable: false),
                    RealEstatesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateRealEstateFeature", x => new { x.RealEstateFeaturesId, x.RealEstatesId });
                    table.ForeignKey(
                        name: "FK_RealEstateRealEstateFeature_RealEstateFeatures_RealEstateFe~",
                        column: x => x.RealEstateFeaturesId,
                        principalTable: "RealEstateFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RealEstateRealEstateFeature_RealEstates_RealEstatesId",
                        column: x => x.RealEstatesId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RealEstateTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LangCode = table.Column<string>(type: "text", nullable: false),
                    Desciription = table.Column<string>(type: "text", nullable: false),
                    RealEstateId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateTranslates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateTranslates_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelEssentialsRealEstate_RealEstatesId",
                table: "HotelEssentialsRealEstate",
                column: "RealEstatesId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateDetails_RealEstateId",
                table: "RealEstateDetails",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateGalleries_RealEstateId",
                table: "RealEstateGalleries",
                column: "RealEstateId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateRealEstateFeature_RealEstatesId",
                table: "RealEstateRealEstateFeature",
                column: "RealEstatesId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateTranslates_RealEstateId",
                table: "RealEstateTranslates",
                column: "RealEstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelEssentialsRealEstate");

            migrationBuilder.DropTable(
                name: "RealEstateDetails");

            migrationBuilder.DropTable(
                name: "RealEstateFeatureTranslates");

            migrationBuilder.DropTable(
                name: "RealEstateGalleries");

            migrationBuilder.DropTable(
                name: "RealEstateRealEstateFeature");

            migrationBuilder.DropTable(
                name: "RealEstateTranslates");

            migrationBuilder.DropTable(
                name: "RealEstateFeatures");

            migrationBuilder.DropTable(
                name: "RealEstates");
        }
    }
}
