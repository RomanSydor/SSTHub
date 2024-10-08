﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SSTHub.Infrastructure.Contexts;

#nullable disable

namespace SSTHub.Infrastructure.Migrations
{
    [DbContext(typeof(SSTHubDbContext))]
    [Migration("20240701160516_HubUpdate")]
    partial class HubUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeService", b =>
                {
                    b.Property<int>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int>("ServicesId")
                        .HasColumnType("int");

                    b.HasKey("EmployeesId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("EmployeeService");

                    b.HasData(
                        new
                        {
                            EmployeesId = 1,
                            ServicesId = 1
                        },
                        new
                        {
                            EmployeesId = 1,
                            ServicesId = 2
                        },
                        new
                        {
                            EmployeesId = 2,
                            ServicesId = 1
                        },
                        new
                        {
                            EmployeesId = 2,
                            ServicesId = 2
                        });
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 1, 16, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "testRA@test.com",
                            FirstName = "Roman",
                            LastName = "Aaaa",
                            Phone = "1111111111"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 1, 14, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "testIB@test.com",
                            FirstName = "Ivan",
                            LastName = "BBBB",
                            Phone = "2222222222"
                        });
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<byte>("Role")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("OrganizationId");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Employees", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 8, 25, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "testDW@test.com",
                            FirstName = "Dmytro",
                            IsActive = true,
                            LastName = "Watson",
                            OrganizationId = 1,
                            Phone = "1231231231",
                            Role = (byte)0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 12, 2, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "testPA@test.com",
                            FirstName = "Petro",
                            IsActive = true,
                            LastName = "Abc",
                            OrganizationId = 2,
                            Phone = "43434343433",
                            Role = (byte)1
                        });
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("HubId")
                        .HasColumnType("int");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartAt")
                        .HasColumnType("datetime2");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("HubId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Events", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 1, 16, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 1,
                            EmployeeId = 1,
                            HubId = 1,
                            ServiceId = 1,
                            StartAt = new DateTime(2024, 1, 18, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = (byte)0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 1, 14, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            CustomerId = 2,
                            EmployeeId = 2,
                            HubId = 2,
                            ServiceId = 2,
                            StartAt = new DateTime(2024, 1, 16, 15, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = (byte)2
                        });
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Hub", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OrganizationId");

                    b.ToTable("Hubs", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 1, 14, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "TestHub1",
                            OrganizationId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 2, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "TestHub2",
                            OrganizationId = 2
                        });
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Organizations", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 1, 14, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "TestOrg1"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 2, 1, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            IsActive = true,
                            Name = "TestOrg2"
                        });
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Services", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 12, 14, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            DurationInMinutes = 60,
                            IsActive = true,
                            Name = "TestService1",
                            Price = 100
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 12, 14, 16, 0, 0, 0, DateTimeKind.Unspecified),
                            DurationInMinutes = 60,
                            IsActive = true,
                            Name = "TestService2",
                            Price = 100
                        });
                });

            modelBuilder.Entity("EmployeeService", b =>
                {
                    b.HasOne("SSTHub.Domain.Entities.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSTHub.Domain.Entities.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Employee", b =>
                {
                    b.HasOne("SSTHub.Domain.Entities.Organization", "Organization")
                        .WithMany("Employees")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Event", b =>
                {
                    b.HasOne("SSTHub.Domain.Entities.Customer", "Customer")
                        .WithMany("Events")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SSTHub.Domain.Entities.Employee", "Employee")
                        .WithMany("Events")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SSTHub.Domain.Entities.Hub", "Hub")
                        .WithMany("Events")
                        .HasForeignKey("HubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SSTHub.Domain.Entities.Service", "Service")
                        .WithMany("Events")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Hub");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Hub", b =>
                {
                    b.HasOne("SSTHub.Domain.Entities.Organization", "Organization")
                        .WithMany("Hubs")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Hub", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Organization", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Hubs");
                });

            modelBuilder.Entity("SSTHub.Domain.Entities.Service", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
