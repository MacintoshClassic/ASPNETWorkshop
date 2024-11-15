﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workshop.Data;

#nullable disable

namespace Workshop.Migrations
{
    [DbContext(typeof(WorkshopContext))]
    [Migration("20240827064201_OrderStatusChanged")]
    partial class OrderStatusChanged
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Workshop.Models.CalculatedRepairCost", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarPartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CarPartQuantity")
                        .HasColumnType("int");

                    b.Property<int>("HoursDedicated")
                        .HasColumnType("int");

                    b.Property<Guid>("MechanicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("PriceTotal")
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.ToTable("CalculatedRepairCost");
                });

            modelBuilder.Entity("Workshop.Models.Car", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("ID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Workshop.Models.CarPart", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CarPartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("OrderStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("PricePerUnit")
                        .HasColumnType("real");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("CarPart");
                });

            modelBuilder.Entity("Workshop.Models.ChargedCar", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Kwh")
                        .HasColumnType("real");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<float>("PriceTotal")
                        .HasColumnType("real");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("ChargedCar");
                });

            modelBuilder.Entity("Workshop.Models.Client", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Workshop.Models.ClientCar", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("ClientCar");
                });

            modelBuilder.Entity("Workshop.Models.Mechanic", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("HourlyRate")
                        .HasColumnType("real");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ID");

                    b.ToTable("Mechanic");
                });

            modelBuilder.Entity("Workshop.Models.OrderStatus", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarPartId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("OrderStatusName")
                        .HasColumnType("int");

                    b.Property<float>("PriceTotal")
                        .HasColumnType("real");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("Workshop.Models.RefueledCar", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<float>("Litres")
                        .HasColumnType("real");

                    b.Property<float>("PriceTotal")
                        .HasColumnType("real");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("RefueledCar");
                });

            modelBuilder.Entity("Workshop.Models.ServiceStatus", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServiceStatusName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("ServiceStatus");
                });

            modelBuilder.Entity("Workshop.Models.ServiceTicket", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CaseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("MechanicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("PriceTotal")
                        .HasColumnType("real");

                    b.Property<Guid>("ServiceStatusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServiceTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("ServiceTicket");
                });

            modelBuilder.Entity("Workshop.Models.ServiceType", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("ServiceType");
                });
#pragma warning restore 612, 618
        }
    }
}
