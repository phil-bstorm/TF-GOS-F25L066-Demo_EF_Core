using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Car_CarOption_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car_CarOption",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false),
                    OptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car_CarOption", x => new { x.CarId, x.OptionId });
                    table.ForeignKey(
                        name: "FK_Car_CarOption_CarOption_OptionId",
                        column: x => x.OptionId,
                        principalTable: "CarOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_CarOption_Vrooooom_CarId",
                        column: x => x.CarId,
                        principalTable: "Vrooooom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Car_CarOption",
                columns: new[] { "CarId", "OptionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_CarOption_OptionId",
                table: "Car_CarOption",
                column: "OptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car_CarOption");
        }
    }
}
