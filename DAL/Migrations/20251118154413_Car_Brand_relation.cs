using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Car_Brand_relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "Vrooooom",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Vrooooom",
                keyColumn: "Id",
                keyValue: 1,
                column: "BrandId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vrooooom",
                keyColumn: "Id",
                keyValue: 2,
                column: "BrandId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Vrooooom_BrandId",
                table: "Vrooooom",
                column: "BrandId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vrooooom_Brand_BrandId",
                table: "Vrooooom",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vrooooom_Brand_BrandId",
                table: "Vrooooom");

            migrationBuilder.DropIndex(
                name: "IX_Vrooooom_BrandId",
                table: "Vrooooom");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "Vrooooom");
        }
    }
}
