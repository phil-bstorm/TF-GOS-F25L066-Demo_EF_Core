using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class car_seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Vrooooom",
                columns: new[] { "Id", "Model", "Price", "RegistrationDate", "State" },
                values: new object[,]
                {
                    { 1, "MX-5", 1000m, new DateTime(2025, 11, 18, 15, 54, 29, 749, DateTimeKind.Local).AddTicks(8744), "FOR_PARTS" },
                    { 2, "Polo", 100m, new DateTime(2025, 11, 18, 15, 54, 29, 749, DateTimeKind.Local).AddTicks(8800), "FOR_PARTS" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vrooooom",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vrooooom",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
