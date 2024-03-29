﻿// <auto-generated />
using System;
using HoneyRaesEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HoneyRaesEF.Migrations
{
    [DbContext(typeof(HoneyRaesEFDbContext))]
    [Migration("20240217183422_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("HoneyRaesEF.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Witch Lane",
                            Name = "Salem"
                        },
                        new
                        {
                            Id = 2,
                            Address = "124 Witch Lane",
                            Name = "Saleoomi"
                        },
                        new
                        {
                            Id = 3,
                            Address = "125 Witch Lane",
                            Name = "Salogna"
                        });
                });

            modelBuilder.Entity("HoneyRaesEF.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Keana",
                            Specialty = "Dealing with Salems"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Kiki",
                            Specialty = "Dealing with Saleoomis"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Kia",
                            Specialty = "Dealing with Salognas"
                        });
                });

            modelBuilder.Entity("HoneyRaesEF.Models.ServiceTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateCompleted")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Emergency")
                        .HasColumnType("boolean");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ServiceTickets");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            DateCompleted = new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The salem needs a Cauldron",
                            Emergency = false,
                            EmployeeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            DateCompleted = new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The saleoomi needs a Cauldron",
                            Emergency = true,
                            EmployeeId = 2
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            Description = "The salogna needs a Cauldron",
                            Emergency = true,
                            EmployeeId = 3
                        });
                });

            modelBuilder.Entity("HoneyRaesEF.Models.ServiceTicket", b =>
                {
                    b.HasOne("HoneyRaesEF.Models.Employee", "Employee")
                        .WithMany("ServiceTickets")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("HoneyRaesEF.Models.Employee", b =>
                {
                    b.Navigation("ServiceTickets");
                });
#pragma warning restore 612, 618
        }
    }
}
