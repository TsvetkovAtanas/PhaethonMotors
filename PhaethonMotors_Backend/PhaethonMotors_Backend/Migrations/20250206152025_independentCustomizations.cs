using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaethonMotors_Backend.Migrations
{
    /// <inheritdoc />
    public partial class independentCustomizations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarModelCustomizations");

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "WheelOptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "TrimOptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "InteriorOptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "FeatureOptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarModelId",
                table: "ColorOptions",
                type: "nvarchar(450)",
                nullable: true);

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FeatureOptions_CarModels_CarModelId",
                table: "FeatureOptions",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InteriorOptions_CarModels_CarModelId",
                table: "InteriorOptions",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TrimOptions_CarModels_CarModelId",
                table: "TrimOptions",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WheelOptions_CarModels_CarModelId",
                table: "WheelOptions",
                column: "CarModelId",
                principalTable: "CarModels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "CarModelCustomizations",
                columns: table => new
                {
                    ColorOptionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FeatureOptionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InteriorOptionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TrimOptionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WheelOptionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModelCustomizations", x => new { x.ColorOptionId, x.FeatureOptionId, x.InteriorOptionId, x.TrimOptionId, x.WheelOptionId });
                    table.ForeignKey(
                        name: "FK_CarModelCustomizations_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CarModelCustomizations_ColorOptions_ColorOptionId",
                        column: x => x.ColorOptionId,
                        principalTable: "ColorOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelCustomizations_FeatureOptions_FeatureOptionId",
                        column: x => x.FeatureOptionId,
                        principalTable: "FeatureOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelCustomizations_InteriorOptions_InteriorOptionId",
                        column: x => x.InteriorOptionId,
                        principalTable: "InteriorOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelCustomizations_TrimOptions_TrimOptionId",
                        column: x => x.TrimOptionId,
                        principalTable: "TrimOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarModelCustomizations_WheelOptions_WheelOptionId",
                        column: x => x.WheelOptionId,
                        principalTable: "WheelOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModelCustomizations_CarModelId",
                table: "CarModelCustomizations",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelCustomizations_FeatureOptionId",
                table: "CarModelCustomizations",
                column: "FeatureOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelCustomizations_InteriorOptionId",
                table: "CarModelCustomizations",
                column: "InteriorOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelCustomizations_TrimOptionId",
                table: "CarModelCustomizations",
                column: "TrimOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModelCustomizations_WheelOptionId",
                table: "CarModelCustomizations",
                column: "WheelOptionId");
        }
    }
}
