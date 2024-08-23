﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workshop.Data;

#nullable disable

namespace Workshop.Migrations
{
    [DbContext(typeof(WorkshopContext))]
    partial class WorkshopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("Workshop.Models.Car", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Year")
                        .HasColumnType("nvarchar(4)");

                    b.HasKey("ID");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("Workshop.Models.CarPart", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CarId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CarPartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("OrderStatusId")
                        .HasColumnType("TEXT");

                    b.Property<float>("PricePerUnit")
                        .HasColumnType("REAL");

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("CarPart");
                });

            modelBuilder.Entity("Workshop.Models.Client", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Workshop.Models.ClientCar", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CarId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ClientId")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("ClientCar");
                });

            modelBuilder.Entity("Workshop.Models.Mechanic", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("HourlyRate")
                        .HasColumnType("REAL");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("ID");

                    b.ToTable("Mechanic");
                });

            modelBuilder.Entity("Workshop.Models.OrderStatus", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderStatusName")
                        .HasColumnType("INTEGER");

                    b.Property<int>("QuantityOrdered")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("Workshop.Models.ServiceTicket", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CarId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CaseDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("MechanicId")
                        .HasColumnType("TEXT");

                    b.Property<float>("PriceTotal")
                        .HasColumnType("REAL");

                    b.Property<Guid>("ServiceStatusId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ServiceTypeId")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("ServiceTicket");
                });
#pragma warning restore 612, 618
        }
    }
}
