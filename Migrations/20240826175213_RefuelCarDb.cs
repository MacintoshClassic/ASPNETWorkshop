﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workshop.Migrations
{
    /// <inheritdoc />
    public partial class RefuelCarDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefueledCar",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Litres = table.Column<float>(type: "real", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriceTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefueledCar", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefueledCar");
        }
    }
}
