using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaethonMotors_Backend.Migrations
{
    /// <inheritdoc />
    public partial class seedDBimgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ColorOptions_CarModels_CarModelId",
                table: "ColorOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_FeatureOptions_CarModels_CarModelId",
                table: "FeatureOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_InteriorOptions_CarModels_CarModelId",
                table: "InteriorOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_TrimOptions_CarModels_CarModelId",
                table: "TrimOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_WheelOptions_CarModels_CarModelId",
                table: "WheelOptions");

            migrationBuilder.DropIndex(
                name: "IX_WheelOptions_CarModelId",
                table: "WheelOptions");

            migrationBuilder.DropIndex(
                name: "IX_TrimOptions_CarModelId",
                table: "TrimOptions");

            migrationBuilder.DropIndex(
                name: "IX_InteriorOptions_CarModelId",
                table: "InteriorOptions");

            migrationBuilder.DropIndex(
                name: "IX_FeatureOptions_CarModelId",
                table: "FeatureOptions");

            migrationBuilder.DropIndex(
                name: "IX_ColorOptions_CarModelId",
                table: "ColorOptions");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "WheelOptions");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "TrimOptions");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "InteriorOptions");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "FeatureOptions");

            migrationBuilder.DropColumn(
                name: "CarModelId",
                table: "ColorOptions");

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
                name: "CarModelFeatureOptions",
                columns: table => new
                {
                    CarModelsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeaturesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelFeatureOptions", x => new { x.CarModelsId, x.FeaturesId });
                    table.ForeignKey(
                        name: "FK_CarModelFeatureOptions_CarModels_CarModelsId",
                        column: x => x.CarModelsId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelFeatureOptions_FeatureOptions_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "FeatureOptions",
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
                name: "IX_CarModelFeatureOptions_FeaturesId",
                table: "CarModelFeatureOptions",
                column: "FeaturesId");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModelColorOptions");

            migrationBuilder.DropTable(
                name: "CarModelFeatureOptions");

            migrationBuilder.DropTable(
                name: "CarModelInteriorOptions");

            migrationBuilder.DropTable(
                name: "CarModelTrimOptions");

            migrationBuilder.DropTable(
                name: "CarModelWheelOptions");

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "WheelOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "TrimOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "InteriorOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "FeatureOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "ColorOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_WheelOptions_CarModelId",
                table: "WheelOptions",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TrimOptions_CarModelId",
                table: "TrimOptions",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InteriorOptions_CarModelId",
                table: "InteriorOptions",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureOptions_CarModelId",
                table: "FeatureOptions",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_ColorOptions_CarModelId",
                table: "ColorOptions",
                column: "CarModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ColorOptions_CarModels_CarModelId",
                table: "ColorOptions",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureOptions_CarModels_CarModelId",
                table: "FeatureOptions",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InteriorOptions_CarModels_CarModelId",
                table: "InteriorOptions",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrimOptions_CarModels_CarModelId",
                table: "TrimOptions",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WheelOptions_CarModels_CarModelId",
                table: "WheelOptions",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
