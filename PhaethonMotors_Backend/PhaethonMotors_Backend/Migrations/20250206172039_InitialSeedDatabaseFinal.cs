using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaethonMotors_Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeedDatabaseFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModelFeatureOptions_FeatureOptions_FeaturesId",
                table: "CarModelFeatureOptions");

            migrationBuilder.DropTable(
                name: "CarModelColorOptions");

            migrationBuilder.DropTable(
                name: "CarModelInteriorOptions");

            migrationBuilder.DropTable(
                name: "CarModelTrimOptions");

            migrationBuilder.DropTable(
                name: "CarModelWheelOptions");

            migrationBuilder.RenameColumn(
                name: "FeaturesId",
                table: "CarModelFeatureOptions",
                newName: "FeatureOptionsId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModelFeatureOptions_FeaturesId",
                table: "CarModelFeatureOptions",
                newName: "IX_CarModelFeatureOptions_FeatureOptionsId");

            migrationBuilder.AddColumn<string>(
                name: "ColorOptionId",
                table: "CarModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InteriorOptionId",
                table: "CarModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TrimOptionId",
                table: "CarModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WheelOptionId",
                table: "CarModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_ColorOptionId",
                table: "CarModels",
                column: "ColorOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_InteriorOptionId",
                table: "CarModels",
                column: "InteriorOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_TrimOptionId",
                table: "CarModels",
                column: "TrimOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_WheelOptionId",
                table: "CarModels",
                column: "WheelOptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelFeatureOptions_FeatureOptions_FeatureOptionsId",
                table: "CarModelFeatureOptions",
                column: "FeatureOptionsId",
                principalTable: "FeatureOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_ColorOptions_ColorOptionId",
                table: "CarModels",
                column: "ColorOptionId",
                principalTable: "ColorOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_InteriorOptions_InteriorOptionId",
                table: "CarModels",
                column: "InteriorOptionId",
                principalTable: "InteriorOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_TrimOptions_TrimOptionId",
                table: "CarModels",
                column: "TrimOptionId",
                principalTable: "TrimOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_WheelOptions_WheelOptionId",
                table: "CarModels",
                column: "WheelOptionId",
                principalTable: "WheelOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModelFeatureOptions_FeatureOptions_FeatureOptionsId",
                table: "CarModelFeatureOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_ColorOptions_ColorOptionId",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_InteriorOptions_InteriorOptionId",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_TrimOptions_TrimOptionId",
                table: "CarModels");

            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_WheelOptions_WheelOptionId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_ColorOptionId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_InteriorOptionId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_TrimOptionId",
                table: "CarModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_WheelOptionId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "ColorOptionId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "InteriorOptionId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "TrimOptionId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "WheelOptionId",
                table: "CarModels");

            migrationBuilder.RenameColumn(
                name: "FeatureOptionsId",
                table: "CarModelFeatureOptions",
                newName: "FeaturesId");

            migrationBuilder.RenameIndex(
                name: "IX_CarModelFeatureOptions_FeatureOptionsId",
                table: "CarModelFeatureOptions",
                newName: "IX_CarModelFeatureOptions_FeaturesId");

            migrationBuilder.CreateTable(
                name: "CarModelColorOptions",
                columns: table => new
                {
                    CarModelsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ColorsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelColorOptions", x => new { x.CarModelsId, x.ColorsId });
                    table.ForeignKey(
                        name: "FK_CarModelColorOptions_CarModels_CarModelsId",
                        column: x => x.CarModelsId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelColorOptions_ColorOptions_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "ColorOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModelInteriorOptions",
                columns: table => new
                {
                    CarModelsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InteriorsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelInteriorOptions", x => new { x.CarModelsId, x.InteriorsId });
                    table.ForeignKey(
                        name: "FK_CarModelInteriorOptions_CarModels_CarModelsId",
                        column: x => x.CarModelsId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelInteriorOptions_InteriorOptions_InteriorsId",
                        column: x => x.InteriorsId,
                        principalTable: "InteriorOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModelTrimOptions",
                columns: table => new
                {
                    CarModelsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrimsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelTrimOptions", x => new { x.CarModelsId, x.TrimsId });
                    table.ForeignKey(
                        name: "FK_CarModelTrimOptions_CarModels_CarModelsId",
                        column: x => x.CarModelsId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelTrimOptions_TrimOptions_TrimsId",
                        column: x => x.TrimsId,
                        principalTable: "TrimOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarModelWheelOptions",
                columns: table => new
                {
                    CarModelsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WheelsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelWheelOptions", x => new { x.CarModelsId, x.WheelsId });
                    table.ForeignKey(
                        name: "FK_CarModelWheelOptions_CarModels_CarModelsId",
                        column: x => x.CarModelsId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelWheelOptions_WheelOptions_WheelsId",
                        column: x => x.WheelsId,
                        principalTable: "WheelOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModelColorOptions_ColorsId",
                table: "CarModelColorOptions",
                column: "ColorsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelInteriorOptions_InteriorsId",
                table: "CarModelInteriorOptions",
                column: "InteriorsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelTrimOptions_TrimsId",
                table: "CarModelTrimOptions",
                column: "TrimsId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelWheelOptions_WheelsId",
                table: "CarModelWheelOptions",
                column: "WheelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModelFeatureOptions_FeatureOptions_FeaturesId",
                table: "CarModelFeatureOptions",
                column: "FeaturesId",
                principalTable: "FeatureOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
