using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhaethonMotors_Backend.Migrations
{
    /// <inheritdoc />
    public partial class subModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubModelId",
                table: "CarModels",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SubModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceIncreace = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubModels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_SubModelId",
                table: "CarModels",
                column: "SubModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarModels_SubModels_SubModelId",
                table: "CarModels",
                column: "SubModelId",
                principalTable: "SubModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarModels_SubModels_SubModelId",
                table: "CarModels");

            migrationBuilder.DropTable(
                name: "SubModels");

            migrationBuilder.DropIndex(
                name: "IX_CarModels_SubModelId",
                table: "CarModels");

            migrationBuilder.DropColumn(
                name: "SubModelId",
                table: "CarModels");
        }
    }
}
