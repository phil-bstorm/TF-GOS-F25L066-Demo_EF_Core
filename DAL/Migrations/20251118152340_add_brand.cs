using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_brand : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mazda" },
                    { 2, "VW" }
                });

            migrationBuilder.UpdateData(
                table: "Vrooooom",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Vrooooom",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2025, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "UK_Brand_name",
                table: "Brand",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.UpdateData(
                table: "Vrooooom",
                keyColumn: "Id",
                keyValue: 1,
                column: "RegistrationDate",
                value: new DateTime(2025, 11, 18, 15, 54, 29, 749, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "Vrooooom",
                keyColumn: "Id",
                keyValue: 2,
                column: "RegistrationDate",
                value: new DateTime(2025, 11, 18, 15, 54, 29, 749, DateTimeKind.Local).AddTicks(8800));
        }
    }
}
