﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using api.Infrastructure.Database;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7307),
                            Name = "Development",
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7358)
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7364),
                            Name = "Marketing",
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7366)
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7367),
                            Name = "Commercial",
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7368)
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

                    b.Property<bool>("IsLocked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("LockedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("LockedBy")
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
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7506),
                            DepartmentId = 1,
                            Email = "john@doe.com",
                            Firstname = "John",
                            HomePhone = "0123456789",
                            IsLocked = false,
                            Lastname = "Doe",
                            SiteId = 1,
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7507)
                        },
                        new
                        {
                            Id = 2,
                            CellPhone = "9876543210",
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7510),
                            DepartmentId = 2,
                            Email = "jane@smith.com",
                            Firstname = "Jane",
                            HomePhone = "9876543210",
                            IsLocked = false,
                            Lastname = "Smith",
                            SiteId = 2,
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7511)
                        },
                        new
                        {
                            Id = 3,
                            CellPhone = "1234567890",
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7514),
                            DepartmentId = 3,
                            Email = "michael@johnson.com",
                            Firstname = "Michael",
                            HomePhone = "1234567890",
                            IsLocked = false,
                            Lastname = "Johnson",
                            SiteId = 3,
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7515)
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
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7473),
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7475)
                        },
                        new
                        {
                            Id = 2,
                            City = "Nantes",
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7477),
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7478)
                        },
                        new
                        {
                            Id = 3,
                            City = "Toulouse",
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7479),
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7480)
                        },
                        new
                        {
                            Id = 4,
                            City = "Nice",
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7482),
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7483)
                        },
                        new
                        {
                            Id = 5,
                            City = "Lile",
                            CreatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7484),
                            UpdatedAt = new DateTime(2024, 3, 10, 15, 36, 35, 652, DateTimeKind.Local).AddTicks(7485)
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
