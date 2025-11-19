using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_CarOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarOption", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CarOption",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Clignotant" },
                    { 2, "Siège chauffant" },
                    { 3, "Ouverture de proximité" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarOption_Name",
                table: "CarOption",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarOption");
        }
    }
}
