using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaethonMotors_Backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Horsepower = table.Column<int>(type: "int", nullable: false),
                    Torque = table.Column<int>(type: "int", nullable: false),
                    TopSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Acceleration = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SeatingCapacity = table.Column<int>(type: "int", nullable: false),
                    CargoSpace = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Transmission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriveType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ColorOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarModelId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ColorOptions_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FeatureOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarModelId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureOptions_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InteriorOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarModelId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InteriorOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InteriorOptions_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrimOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceIncrease = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HorsepowerIncrease = table.Column<int>(type: "int", nullable: false),
                    Suspension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarModelId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrimOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrimOptions_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WheelOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarModelId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WheelOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WheelOptions_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColorOptions_CarModelId",
                table: "ColorOptions",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureOptions_CarModelId",
                table: "FeatureOptions",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InteriorOptions_CarModelId",
                table: "InteriorOptions",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TrimOptions_CarModelId",
                table: "TrimOptions",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_WheelOptions_CarModelId",
                table: "WheelOptions",
                column: "CarModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColorOptions");

            migrationBuilder.DropTable(
                name: "FeatureOptions");

            migrationBuilder.DropTable(
                name: "InteriorOptions");

            migrationBuilder.DropTable(
                name: "TrimOptions");

            migrationBuilder.DropTable(
                name: "WheelOptions");

            migrationBuilder.DropTable(
                name: "CarModels");
        }
    }
}
