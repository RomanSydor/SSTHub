using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSTHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 54, 9, 147, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 54, 9, 147, DateTimeKind.Local).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 54, 9, 148, DateTimeKind.Local).AddTicks(2483));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 54, 9, 148, DateTimeKind.Local).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartAt" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 54, 9, 148, DateTimeKind.Local).AddTicks(5833), new DateTime(2024, 1, 17, 15, 54, 9, 148, DateTimeKind.Local).AddTicks(5863) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartAt" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 54, 9, 148, DateTimeKind.Local).AddTicks(5875), new DateTime(2024, 1, 15, 15, 54, 9, 148, DateTimeKind.Local).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "Hubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 54, 9, 149, DateTimeKind.Local).AddTicks(2490));

            migrationBuilder.UpdateData(
                table: "Hubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 54, 9, 149, DateTimeKind.Local).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 54, 9, 149, DateTimeKind.Local).AddTicks(7243));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 54, 9, 149, DateTimeKind.Local).AddTicks(7280));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7581));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7599));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "StartAt" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7748), new DateTime(2024, 1, 17, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7755) });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartAt" },
                values: new object[] { new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7781), new DateTime(2024, 1, 15, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7788) });

            migrationBuilder.UpdateData(
                table: "Hubs",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(6576));

            migrationBuilder.UpdateData(
                table: "Hubs",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(6709));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 1, 16, 15, 22, 46, 189, DateTimeKind.Local).AddTicks(7401));
        }
    }
}
