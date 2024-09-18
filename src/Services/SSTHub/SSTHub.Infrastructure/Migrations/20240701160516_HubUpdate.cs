using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSTHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HubUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Hubs_HubId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_HubId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "HubId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HubId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "HubId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "HubId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HubId",
                table: "Employees",
                column: "HubId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Hubs_HubId",
                table: "Employees",
                column: "HubId",
                principalTable: "Hubs",
                principalColumn: "Id");
        }
    }
}
