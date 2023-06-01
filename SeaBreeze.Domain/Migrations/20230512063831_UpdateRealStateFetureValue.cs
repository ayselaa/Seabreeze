using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SeaBreeze.Domain.Migrations
{
    public partial class UpdateRealStateFetureValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureRealEstate");

            migrationBuilder.AddColumn<int>(
                name: "FeatureId",
                table: "FeatureTranslates",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeatureRealEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeatureId = table.Column<int>(type: "integer", nullable: false),
                    RealEstateId = table.Column<int>(type: "integer", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureRealEstates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureRealEstates_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeatureRealEstates_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureTranslates_FeatureId",
                table: "FeatureTranslates",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureRealEstates_FeatureId",
                table: "FeatureRealEstates",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureRealEstates_RealEstateId",
                table: "FeatureRealEstates",
                column: "RealEstateId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureTranslates_Features_FeatureId",
                table: "FeatureTranslates",
                column: "FeatureId",
                principalTable: "Features",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeatureTranslates_Features_FeatureId",
                table: "FeatureTranslates");

            migrationBuilder.DropTable(
                name: "FeatureRealEstates");

            migrationBuilder.DropIndex(
                name: "IX_FeatureTranslates_FeatureId",
                table: "FeatureTranslates");

            migrationBuilder.DropColumn(
                name: "FeatureId",
                table: "FeatureTranslates");

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
    }
}
