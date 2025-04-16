using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaethonMotors_Backend.Migrations
{
    /// <inheritdoc />
    public partial class independentFixFinal : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "WheelOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "TrimOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "InteriorOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "FeatureOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "ColorOptions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "WheelOptions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "TrimOptions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "InteriorOptions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "FeatureOptions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "CarModelId",
                table: "ColorOptions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
