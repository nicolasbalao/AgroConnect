using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeLockingSystem : Migration
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

            migrationBuilder.AddColumn<DateTime>(
                name: "LockedAt",
                table: "Employees",
                type: "datetime(6)",
                nullable: true);

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
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7307), new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7358) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7364), new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7366) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7367), new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7368) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsLocked", "LockedAt", "LockedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7506), false, null, null, new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7507) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsLocked", "LockedAt", "LockedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7510), false, null, null, new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7511) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsLocked", "LockedAt", "LockedBy", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7514), false, null, null, new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7515) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7473), new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7477), new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7478) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7479), new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7480) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7482), new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7483) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7484), new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7485) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLocked",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LockedAt",
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
