using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SSTHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7581), "testRA@test.com", "Roman", "Aaaa", "1111111111" },
                    { 2, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7599), "testIB@test.com", "Ivan", "BBBB", "2222222222" }
                });

            migrationBuilder.InsertData(
                table: "Hubs",
                columns: new[] { "Id", "CreatedAt", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(6576), true, "TestHub1" },
                    { 2, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(6709), true, "TestHub2" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "DurationInMinutes", "IsActive", "Name", "Price" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7384), 60, true, "TestService1", 100 },
                    { 2, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7401), 60, true, "TestService2", 100 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "HubId", "IsActive", "LastName", "Phone", "Position" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7670), "testDW@test.com", "Dmytro", 1, true, "Watson", "1231231231", (byte)0 },
                    { 2, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7687), "testPA@test.com", "Petro", 2, true, "Abc", "43434343433", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "EmployeeId", "HubId", "IsActive", "ServiceId", "StartAt", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7748), 1, 1, 1, true, 1, new DateTime(2024, 1, 17, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7755), (byte)0 },
                    { 2, new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7781), 2, 2, 2, true, 2, new DateTime(2024, 1, 15, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7788), (byte)1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hubs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hubs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
