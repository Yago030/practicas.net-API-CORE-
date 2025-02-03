using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MinimalAPISeeds.Migrations
{
    /// <inheritdoc />
    public partial class Entidades2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crops_Seasons_SeasonId",
                table: "Crops");

            migrationBuilder.DropIndex(
                name: "IX_Crops_SeasonId",
                table: "Crops");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Crops");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Seasons",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "CropSeasons",
                columns: table => new
                {
                    CropsId = table.Column<int>(type: "int", nullable: false),
                    SeasonsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CropSeasons", x => new { x.CropsId, x.SeasonsId });
                    table.ForeignKey(
                        name: "FK_CropSeasons_Crops_CropsId",
                        column: x => x.CropsId,
                        principalTable: "Crops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CropSeasons_Seasons_SeasonsId",
                        column: x => x.SeasonsId,
                        principalTable: "Seasons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CropSeasons_SeasonsId",
                table: "CropSeasons",
                column: "SeasonsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CropSeasons");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Seasons",
                newName: "Nombre");

            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Crops",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Crops_SeasonId",
                table: "Crops",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crops_Seasons_SeasonId",
                table: "Crops",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
