using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class RenameServiceToDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Services_ServiceId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "Employees",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ServiceId",
                table: "Employees",
                newName: "IX_Employees_DepartmentId");

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9232), "Development", new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9297) },
                    { 2, new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9304), "Marketing", new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9306) },
                    { 3, new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9308), "Commercial", new DateTime(2024, 3, 7, 17, 47, 51, 926, DateTimeKind.Local).AddTicks(9310) }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepartmentId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Employees",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                newName: "IX_Employees_ServiceId");

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9885), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9888), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9889) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9891), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9892) });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9717), "Development", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9754) },
                    { 2, new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9758), "Marketing", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9759) },
                    { 3, new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9761), "Commercial", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9762) }
                });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9854), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9855) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9857), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9858) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9859), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9860) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9861), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9862) });

            migrationBuilder.UpdateData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9863), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9864) });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Services_ServiceId",
                table: "Employees",
                column: "ServiceId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
