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
                name: "IsModifiable",
                table: "Employees",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4561), new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4615) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4622), new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4623) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4625), new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4626) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IsModifiable", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4769), true, new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4770) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IsModifiable", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4773), true, new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4774) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "IsModifiable", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4777), true, new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4778) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4736), new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4739), new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4740) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4742), new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4743) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4745), new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4746) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4747), new DateTime(2024, 3, 10, 13, 44, 53, 212, DateTimeKind.Local).AddTicks(4748) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsModifiable",
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
