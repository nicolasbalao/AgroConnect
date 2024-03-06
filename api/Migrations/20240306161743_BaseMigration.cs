using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Services",
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
                    table.PrimaryKey("PK_Services", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Firstname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Lastname = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HomePhone = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CellPhone = table.Column<string>(type: "varchar(20)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SiteId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9717), "Development", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9754) },
                    { 2, new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9758), "Marketing", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9759) },
                    { 3, new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9761), "Commercial", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9762) }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "City", "CreatedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "Paris", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9854), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9855) },
                    { 2, "Nantes", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9857), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9858) },
                    { 3, "Toulouse", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9859), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9860) },
                    { 4, "Nice", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9861), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9862) },
                    { 5, "Lile", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9863), new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9864) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CellPhone", "CreatedAt", "Email", "Firstname", "HomePhone", "Lastname", "ServiceId", "SiteId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "0123456789", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9885), "john@doe.com", "John", "0123456789", "Doe", 1, 1, new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9886) },
                    { 2, "9876543210", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9888), "jane@smith.com", "Jane", "9876543210", "Smith", 2, 2, new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9889) },
                    { 3, "1234567890", new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9891), "michael@johnson.com", "Michael", "1234567890", "Johnson", 3, 3, new DateTime(2024, 3, 6, 17, 17, 43, 164, DateTimeKind.Local).AddTicks(9892) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ServiceId",
                table: "Employees",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SiteId",
                table: "Employees",
                column: "SiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Sites");
        }
    }
}
