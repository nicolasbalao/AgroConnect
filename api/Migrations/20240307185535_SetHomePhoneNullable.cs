using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SetHomePhoneNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HomePhone",
                table: "Employees",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "HomePhone",
                keyValue: null,
                column: "HomePhone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "HomePhone",
                table: "Employees",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9232), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9297) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9304), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9306) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9308), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9541), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9542) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9546), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9547) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9550), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9551) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9498), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9500) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9502), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9504) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9506), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9507) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9509), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9510) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9512), new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9513) });
        }
    }
}
