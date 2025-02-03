using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPISeeds.Migrations
{
    /// <inheritdoc />
    public partial class Entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeasonId = table.Column<int>(type: "int", nullable: false),
                    Spacing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinHarvestDays = table.Column<int>(type: "int", nullable: false),
                    MaxHarvestDays = table.Column<int>(type: "int", nullable: false),
                    PlantingDates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Varieties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaterRequirement = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crops_Seasons_SeasonId",
                        column: x => x.SeasonId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlantingMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlantingMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CropPlantingMethods",
                columns: table => new
                {
                    CropsId = table.Column<int>(type: "int", nullable: false),
                    PlantingMethodsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropPlantingMethods", x => new { x.CropsId, x.PlantingMethodsId });
                    table.ForeignKey(
                        name: "FK_CropPlantingMethods_Crops_CropsId",
                        column: x => x.CropsId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropPlantingMethods_PlantingMethods_PlantingMethodsId",
                        column: x => x.PlantingMethodsId,
                        principalTable: "PlantingMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CropPlantingMethods_PlantingMethodsId",
                table: "CropPlantingMethods",
                column: "PlantingMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Crops_SeasonId",
                table: "Crops",
                column: "SeasonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CropPlantingMethods");

            migrationBuilder.DropTable(
                name: "Crops");

            migrationBuilder.DropTable(
                name: "PlantingMethods");
        }
    }
}
