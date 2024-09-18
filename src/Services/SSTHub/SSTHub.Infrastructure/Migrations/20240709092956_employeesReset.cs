using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SSTHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class employeesReset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: (byte)0);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "IsActive", "LastName", "OrganizationId", "Phone", "Role" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 12, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "testAT@test.com", "Alex", true, "Test", 1, "43433343433", (byte)1 },
                    { 4, new DateTime(2023, 12, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "testRT@test.com", "Rob", true, "Test", 2, "43433343513", (byte)1 },
                    { 5, new DateTime(2023, 12, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "testST@test.com", "Sam", true, "Test", 1, "43433343213", (byte)2 },
                    { 6, new DateTime(2023, 12, 2, 15, 0, 0, 0, DateTimeKind.Unspecified), "testJT@test.com", "John", true, "Test", 2, "43466643513", (byte)2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "Role",
                value: (byte)1);
        }
    }
}
