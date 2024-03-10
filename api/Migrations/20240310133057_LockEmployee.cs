using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class LockEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLocked",
                table: "Employees",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LockedBy",
                table: "Employees",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2483), new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2526) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2531), new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2532) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2534), new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2535) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsLocked", "LockedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2692), false, "", new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2693) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsLocked", "LockedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2696), false, "", new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2697) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsLocked", "LockedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2699), false, "", new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2700) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2659), new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2662) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2663), new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2664) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2666), new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2667) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2668), new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2669) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2671), new DateTime(2024, 3, 10, 14, 30, 57, 613, DateTimeKind.Local).AddTicks(2672) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LockedBy",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5493), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5562) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5570), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5571) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5573), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5575) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5765), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5766) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5770), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5771) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5774), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5775) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5721), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5724) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5727), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5729) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5731), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5732) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5734), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5735) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5737), new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5738) });
        }
    }
}
