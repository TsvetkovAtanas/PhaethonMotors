using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaethonMotors_Backend.Migrations
{
    /// <inheritdoc />
    public partial class users : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomizedCars",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CarModelId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedColorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedInteriorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedWheelsId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedTrimId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelectedFeaturesIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sketchModelUID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SavedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomizedCars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomizedCars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomizedCars_UserId",
                table: "CustomizedCars",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomizedCars");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
