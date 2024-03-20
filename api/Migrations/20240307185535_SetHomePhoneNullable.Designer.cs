﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using api.Infrastructure.Database;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240307185535_SetHomePhoneNullable")]
    partial class SetHomePhoneNullable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("api.Model.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5493),
                            Name = "Development",
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5562)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5570),
                            Name = "Marketing",
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5571)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5573),
                            Name = "Commercial",
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5575)
                        });
                });

            modelBuilder.Entity("api.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CellPhone")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HomePhone")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SiteId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CellPhone = "0123456789",
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5765),
                            DepartmentId = 1,
                            Email = "john@doe.com",
                            Firstname = "John",
                            HomePhone = "0123456789",
                            Lastname = "Doe",
                            SiteId = 1,
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5766)
                        },
                        new
                        {
                            Id = 2,
                            CellPhone = "9876543210",
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5770),
                            DepartmentId = 2,
                            Email = "jane@smith.com",
                            Firstname = "Jane",
                            HomePhone = "9876543210",
                            Lastname = "Smith",
                            SiteId = 2,
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5771)
                        },
                        new
                        {
                            Id = 3,
                            CellPhone = "1234567890",
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5774),
                            DepartmentId = 3,
                            Email = "michael@johnson.com",
                            Firstname = "Michael",
                            HomePhone = "1234567890",
                            Lastname = "Johnson",
                            SiteId = 3,
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5775)
                        });
                });

            modelBuilder.Entity("api.Model.Site", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Sites");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Paris",
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5721),
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5724)
                        },
                        new
                        {
                            Id = 2,
                            City = "Nantes",
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5727),
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5729)
                        },
                        new
                        {
                            Id = 3,
                            City = "Toulouse",
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5731),
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5732)
                        },
                        new
                        {
                            Id = 4,
                            City = "Nice",
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5734),
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5735)
                        },
                        new
                        {
                            Id = 5,
                            City = "Lile",
                            CreatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5737),
                            UpdatedAt = new DateTime(2024, 3, 7, 19, 55, 35, 41, DateTimeKind.Local).AddTicks(5738)
                        });
                });

            modelBuilder.Entity("api.Model.Employee", b =>
                {
                    b.HasOne("api.Model.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Model.Site", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Site");
                });
#pragma warning restore 612, 618
        }
    }
}
