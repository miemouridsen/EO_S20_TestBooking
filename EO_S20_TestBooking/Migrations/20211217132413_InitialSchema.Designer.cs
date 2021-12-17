﻿// <auto-generated />
using System;
using EO_S20_TestBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EO_S20_TestBooking.Migrations
{
    [DbContext(typeof(BookingDbContext))]
    [Migration("20211217132413_InitialSchema")]
    partial class InitialSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EO_S20_TestBooking.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("LocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Ssn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.ToTable("Appointments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("621132f3-699c-44aa-89ac-9e0a0a9a123d"),
                            Date = new DateTime(2021, 12, 18, 12, 20, 0, 0, DateTimeKind.Unspecified),
                            LocationId = new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"),
                            Ssn = "1001001000"
                        },
                        new
                        {
                            Id = new Guid("2d68ac3c-ec9f-4bfe-b43c-301358e1ae83"),
                            Date = new DateTime(2021, 12, 18, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            LocationId = new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"),
                            Ssn = "1001001001"
                        },
                        new
                        {
                            Id = new Guid("3fe93d4f-e863-4a56-b172-5623eabe92ae"),
                            Date = new DateTime(2021, 12, 19, 12, 40, 0, 0, DateTimeKind.Unspecified),
                            LocationId = new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"),
                            Ssn = "1001001002"
                        },
                        new
                        {
                            Id = new Guid("076e23be-191f-4405-9d94-57512ba9b112"),
                            Date = new DateTime(2021, 12, 19, 12, 50, 0, 0, DateTimeKind.Unspecified),
                            LocationId = new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"),
                            Ssn = "1001001003"
                        },
                        new
                        {
                            Id = new Guid("0d9cd0ee-80a3-402c-b9b3-180557ff5ac9"),
                            Date = new DateTime(2021, 12, 18, 12, 20, 0, 0, DateTimeKind.Unspecified),
                            LocationId = new Guid("4bb754b7-2c67-404e-a9db-83f487a6ea99"),
                            Ssn = "1001001000"
                        },
                        new
                        {
                            Id = new Guid("fc24f192-8d42-423e-bd3b-f987ffa67b4c"),
                            Date = new DateTime(2021, 12, 18, 12, 30, 0, 0, DateTimeKind.Unspecified),
                            LocationId = new Guid("4bb754b7-2c67-404e-a9db-83f487a6ea99"),
                            Ssn = "1001001001"
                        },
                        new
                        {
                            Id = new Guid("49353586-1124-4ab6-9c8e-d20724ee10c0"),
                            Date = new DateTime(2021, 12, 18, 12, 40, 0, 0, DateTimeKind.Unspecified),
                            LocationId = new Guid("3fceecc9-75e6-4fa6-82f0-8367161c6b42"),
                            Ssn = "1001001002"
                        },
                        new
                        {
                            Id = new Guid("6e8a3006-b3fd-48b5-9034-9efffcde3524"),
                            Date = new DateTime(2021, 12, 19, 12, 50, 0, 0, DateTimeKind.Unspecified),
                            LocationId = new Guid("3fceecc9-75e6-4fa6-82f0-8367161c6b42"),
                            Ssn = "1001001003"
                        });
                });

            modelBuilder.Entity("EO_S20_TestBooking.Models.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bcb3dd9d-555a-4418-b361-b96b93e4d766"),
                            Address = "Paludan mullersvej 24, 8200 Aarhus N"
                        },
                        new
                        {
                            Id = new Guid("4bb754b7-2c67-404e-a9db-83f487a6ea99"),
                            Address = "Finlandsgade 67, 8200 Aarhus N"
                        },
                        new
                        {
                            Id = new Guid("3fceecc9-75e6-4fa6-82f0-8367161c6b42"),
                            Address = "Møllegårdsvej 1, 8200 Aarhus N"
                        });
                });

            modelBuilder.Entity("EO_S20_TestBooking.Models.Appointment", b =>
                {
                    b.HasOne("EO_S20_TestBooking.Models.Location", "Location")
                        .WithMany("Appointments")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("EO_S20_TestBooking.Models.Location", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}