using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class UpdateRealState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateFeatureTranslates");

            migrationBuilder.DropTable(
                name: "RealEstateRealEstateFeature");

            migrationBuilder.DropTable(
                name: "RealEstateFeatures");

            migrationBuilder.RenameColumn(
                name: "Detail",
                table: "RealEstateDetails",
                newName: "Desciription");

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Logo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureTranslates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LangCode = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureTranslates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeatureRealEstate",
                columns: table => new
                {
                    RealEstateFeaturesId = table.Column<int>(type: "integer", nullable: false),
                    RealEstatesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureRealEstate", x => new { x.RealEstateFeaturesId, x.RealEstatesId });
                    table.ForeignKey(
                        name: "FK_FeatureRealEstate_Features_RealEstateFeaturesId",
                        column: x => x.RealEstateFeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureRealEstate_RealEstates_RealEstatesId",
                        column: x => x.RealEstatesId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureRealEstate_RealEstatesId",
                table: "FeatureRealEstate",
                column: "RealEstatesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureRealEstate");

            migrationBuilder.DropTable(
                name: "FeatureTranslates");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.RenameColumn(
                name: "Desciription",
                table: "RealEstateDetails",
                newName: "Detail");

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

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateRealEstateFeature_RealEstatesId",
                table: "RealEstateRealEstateFeature",
                column: "RealEstatesId");
        }
    }
}
